using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Extensions.ManagedClient;
using SDO.SnipsAI.Client.Hermes.AudioServer;
using SDO.SnipsAI.Client.Hermes.Dialog;
using SDO.SnipsAI.Client.Hermes.Tts;
using SDO.SnipsAI.Client.Hermes.Wakeword;

namespace SDO.SnipsAI.Client
{
    /// <summary>
    /// Implementation of a client for snips.ai based on 
    /// * MQTTnet client
    /// 
    /// </summary>
    public class SnipsClient : ISnipsApi, IMqttApplicationMessageReceivedHandler, IMqttClientConnectedHandler
    {
        public const string WakewordToogleWakewordOnQueueName = "hermes/hotword/toggleOn";

        public const string WakewordToogleWakewordOffQueueName = "hermes/hotword/toggleOff";

        public const string WakewordOnDetectedQueueName = "hermes/hotword/#/detected";

        public const string AsrToogleOnQueueName = "hermes/asr/toggleOn";

        public const string AsrToogleOffQueueName = "hermes/asr/toggleOff";

        public const string AsrStartListeningQueueName = "hermes/asr/startListening";

        public const string AsrStopListeningQueueName = "hermes/asr/stopListening";

        public const string FeedbackToogleSoundOnQueueName = "hermes/feedback/sound/toggleOn";

        public const string FeedbackToogleSoundOffQueueName = "hermes/feedback/sound/toggleOff";

        public const string DialogSessionStartedMessageQueueName = "hermes/dialogueManager/sessionStarted";

        public const string DialogSessionQueuedMessageQueueName = "hermes/dialogueManager/sessionQueued";

        public const string DialogSessionEndedMessageQueueName = "hermes/dialogueManager/sessionEnded";

        public const string DialogStartSessionMessageQueueName = "hermes/dialogueManager/startSession";

        public const string DialogIntentNotRecognizedMessageQueueName = "hermes/dialogueManager/intentNotRecognized";

        public const string DialogContinoueSessionMessageQueueName = "hermes/dialogueManager/continueSession";

        public const string DialogEndSessionMessageQueueName = "hermes/dialogueManager/endSession";

        public const string DialogIntentMessageQueueName = "hermes/intent/#";

        public const string NluIntentMessageQueueName = "hermes/nlu/intentParsed";

        public const string AudioFrameMessageQueueName = "hermes/audioServer/#/audioFrame";

        public const string TtsMessageQueueName = "hermes/tts/say";

        /// <summary>
        /// Instance of random for internal usage
        /// </summary>
        private Random _random = new Random();

        /// <summary>
        /// Factory for MQTT clients
        /// </summary>
        private MQTTnet.MqttFactory _factory;

        /// <summary>
        /// Client for communication with MQTT server
        /// </summary>
        private MQTTnet.Extensions.ManagedClient.IManagedMqttClient _client;

        /// <summary>
        /// Dictionary with the registered dialogs
        /// </summary>
        private readonly ConcurrentDictionary<string, IDialog> _dialogMap = new ConcurrentDictionary<string, IDialog>();

        /// <summary>
        /// Dictionay with the active sessions 
        /// </summary>
        private readonly ConcurrentDictionary<string, Session> _sessionMap = new ConcurrentDictionary<string, Session>();

        /// <summary>
        /// Default constructor
        /// </summary>
        public SnipsClient()
        {
            _factory = new MQTTnet.MqttFactory();
        }

        /// <summary>
        /// Connects to the MQTT broker
        /// </summary>
        public async Task Connect(string url)
        {
            var clientOptions = new ManagedMqttClientOptions
            {
                ClientOptions = new MqttClientOptions
                {
                    ClientId = "SDO.SnipsAi.Client",
                    ChannelOptions = new MqttClientTcpOptions
                    {
                        Server = url
                    }
                },

                AutoReconnectDelay = TimeSpan.FromSeconds(1),
            };

            await Connect(clientOptions);
        }

        public async Task Connect(ManagedMqttClientOptions clientOptions)
        {
            var client = _factory.CreateManagedMqttClient();
            _client = client;

            client.ApplicationMessageReceivedHandler = this;
            client.ConnectedHandler = this;
            await client.StartAsync(clientOptions);
        }

        /// <summary>
        /// Disconnects from the MQTT broker
        /// </summary>
        public async Task Disconnect()
        {
            await _client?.StopAsync();
        }

        /// <summary>
        /// The handler is called on the mqtt client has successfully connected 
        /// </summary>
        /// <param name="eventArgs"></param>
        /// <returns></returns>
        public async Task HandleConnectedAsync(MqttClientConnectedEventArgs eventArgs)
        {
            Console.WriteLine("### CONNECTED WITH SERVER ###");

            await _client.SubscribeAsync(DialogIntentMessageQueueName);
            if (OnFrameReceivedHandler != null)
            {
                await _client.SubscribeAsync(AudioFrameMessageQueueName);
            }
            await _client.SubscribeAsync(DialogSessionStartedMessageQueueName);
            await _client.SubscribeAsync(DialogSessionQueuedMessageQueueName);
            await _client.SubscribeAsync(DialogSessionEndedMessageQueueName);
            await _client.SubscribeAsync(DialogIntentNotRecognizedMessageQueueName);

            Console.WriteLine("### SUBSCRIBED ###");
        }

        /// <summary>
        /// This handler is called once the connected MQTT client receives a message on the subscribed topics
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public async Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs e)
        {
            string wildCardContent = null;

            if (IsQueue(AudioFrameMessageQueueName, e.ApplicationMessage.Topic, out wildCardContent))
            {
                var handler = OnFrameReceivedHandler;
                if(handler != null)
                {
                    await handler.HandleOnFrameReceviedAsync(wildCardContent, e.ApplicationMessage.Payload);
                }
            }
            else
            {
                var payLoadString = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);

                Console.WriteLine("### RECEIVED APPLICATION MESSAGE ###");
                Console.WriteLine($"+ Topic = {e.ApplicationMessage.Topic}");
                Console.WriteLine($"+ Payload = {payLoadString}");
                Console.WriteLine($"+ QoS = {e.ApplicationMessage.QualityOfServiceLevel}");
                Console.WriteLine($"+ Retain = {e.ApplicationMessage.Retain}");
                Console.WriteLine();

                if (IsQueue(DialogSessionStartedMessageQueueName, e.ApplicationMessage.Topic, out wildCardContent))
                {
                    var sessionStartedMessage = Newtonsoft.Json.JsonConvert.DeserializeObject<SessionStartedMessage>(payLoadString);
                    var session = new Session(sessionStartedMessage.SessionId, sessionStartedMessage.SiteId);
                    _sessionMap.AddOrUpdate(session.Id, session, (a, b) => session);

                    var handler = OnSessionStartedHandler;
                    if(handler != null)
                    {
                        await handler.HandleOnSessionStartedAsync(sessionStartedMessage);
                    }
                }
                else if (IsQueue(DialogSessionQueuedMessageQueueName, e.ApplicationMessage.Topic, out wildCardContent))
                {
                    var sessionQueuedMessage = Newtonsoft.Json.JsonConvert.DeserializeObject<SessionQueuedMessage>(payLoadString);

                    var handler = OnSessionQueuedHandler;
                    if (handler != null)
                    {
                        await handler.HandleOnSessionQueuedAsync(sessionQueuedMessage);
                    }
                }
                else if (IsQueue(DialogIntentNotRecognizedMessageQueueName, e.ApplicationMessage.Topic, out wildCardContent))
                {
                    var intentNotRecognizedMessage = Newtonsoft.Json.JsonConvert.DeserializeObject<IntentNotRecognizedMessage>(payLoadString);

                    var handler = OnIntentNotRecognizedHandler;
                    if (handler != null)
                    {
                        await handler.HandleOnIntentNotRecognizedAsync(intentNotRecognizedMessage);
                    }
                }
                else if (IsQueue(DialogSessionEndedMessageQueueName, e.ApplicationMessage.Topic, out wildCardContent))
                {
                    var sessionEndedMessage = Newtonsoft.Json.JsonConvert.DeserializeObject<SessionEndedMessage>(payLoadString);

                    Session existingSession = null;
                    if(_sessionMap.TryRemove(sessionEndedMessage.SessionId, out existingSession))
                    {
                        existingSession.OnEnded(sessionEndedMessage.Termination);
                    }

                    var handler = OnSessionEndedHandler;
                    if (handler != null)
                    {
                        await handler.HandleOnSessionEndedAsync(sessionEndedMessage);
                    }
                }
                else if (IsQueue(DialogIntentMessageQueueName, e.ApplicationMessage.Topic, out wildCardContent))
                {
                    var parsedIntend = Newtonsoft.Json.JsonConvert.DeserializeObject<IntentMessage>(payLoadString);

                    Session existingSession = null;
                    _sessionMap.TryGetValue(parsedIntend.SessionId, out existingSession);
                    existingSession.IntentMessages.Add(parsedIntend);

                    if (existingSession.Dialog != null)
                    {
                        await existingSession.Dialog.OnIntentAsync(parsedIntend, existingSession);
                    }
                    else
                    {
                        IDialog foundDialog = null;

                        if (_dialogMap.TryGetValue(parsedIntend.Intent.Name, out foundDialog))
                        {
                            existingSession.SetDialog(foundDialog);
                            await foundDialog.OnIntentAsync(parsedIntend, existingSession);
                        }
                    }
                }
            }
        }


        public void RegisterDialog(IDialog dialog)
        {
            if (!_dialogMap.ContainsKey(dialog.InitialIntendName))
            {
                _dialogMap.AddOrUpdate(dialog.InitialIntendName, dialog, (x, y) => dialog);
                dialog.OnRegistration(this);
            }
        }

        public void UnregisterDialog(IDialog dialog)
        {
            IDialog foundDialog;
            if (_dialogMap.TryRemove(dialog.InitialIntendName, out foundDialog))
            {
                foundDialog.OnUnregistration();
            }
        }

        #region ITtsApi


        /// <inheritdoc/>
        public ITtsOnSayFinishedHandler OnSayFinishedHandler { get; set; }

        /// <inheritdoc/>
        public async Task SendSayMessageAsync(SayMessage message)
        {
            var text = Newtonsoft.Json.JsonConvert.SerializeObject(message);
            await _client.PublishAsync(TtsMessageQueueName, text);
        }


        #endregion

        #region IDialogAPI

        /// <inheritdoc/>
        public IDialogOnIntentDetectedHandler OnIntentDetectedHandler { get; set; }

        /// <inheritdoc/>
        public IDialogOnIntentNotRecognizedHandler OnIntentNotRecognizedHandler { get; set; }

        /// <inheritdoc/>
        public IDialogOnSessionStartedHandler OnSessionStartedHandler { get; set; }

        /// <inheritdoc/>
        public IDialogOnSessionQueuedHandler OnSessionQueuedHandler { get; set; }

        /// <inheritdoc/>
        public IDialogOnSessionEndedHandler OnSessionEndedHandler { get; set; }

        /// <inheritdoc/>
        public async Task StartSessionAsync()
        {
            await StartSessionAsync(text: null);
        }

        /// <inheritdoc/>
        public async Task StartSessionAsync(StartSessionMessage message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            var serializedMessage = Newtonsoft.Json.JsonConvert.SerializeObject(message);
            await _client.PublishAsync(DialogStartSessionMessageQueueName, serializedMessage);
        }

        /// <inheritdoc/>
        public async Task StartSessionAsync(string text = null, bool canBeEnqueued = true, bool sendIntentNotRecognized = false, string customData = null, string siteId = null, params string[] allowedIntents)
        {
            var message = new StartSessionMessage()
            {
                SiteId = siteId,
                CustomData = customData,
                Initialization = new StartSessionAction() {  CanBeEnqueued = canBeEnqueued, SendIntentNotRecognized = sendIntentNotRecognized, FilteredIntents = allowedIntents, Text = text}
            };

            await StartSessionAsync(message);
        }

        /// <inheritdoc/>
        public async Task ContinueSessionAsync(ContinueSessionMessage message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            var serializedMessage = Newtonsoft.Json.JsonConvert.SerializeObject(message);
            await _client.PublishAsync(DialogContinoueSessionMessageQueueName, serializedMessage);
        }

        /// <inheritdoc/>
        public async Task ContinueSessionAsync(string sessionId, string text, bool sendIntentNotRecognized = false, string customerData = null, string slot = null, params string[] allowedIntents)
        {
            var message = new ContinueSessionMessage()
            {
                SessionId = sessionId,
                Text = text,
                SendIntentNotRecognized = sendIntentNotRecognized,
                Slot = slot,
                CustomData = customerData,
                FilteredIntents = allowedIntents
            };

            await ContinueSessionAsync(message);
        }

        /// <inheritdoc/>
        public async Task EndSessionAsync(EndSessionMessage message)
        {
            var serializedMessage = Newtonsoft.Json.JsonConvert.SerializeObject(message);
            await _client.PublishAsync(DialogEndSessionMessageQueueName, serializedMessage);
        }

        /// <inheritdoc/>
        public async Task EndSessionAsync(string sessionId, string text)
        {
            var message = new EndSessionMessage() { SessionId = sessionId, Text = text };
            await EndSessionAsync(message);
        }

        #endregion

        #region Feedback API


        /// <inheritdoc/>
        public async Task ToggleFeedbackSoundOnAsync(string siteId)
        {
            string message = $"{{\"siteId\": \"{siteId}\"}}";
            await _client.PublishAsync(FeedbackToogleSoundOnQueueName, message);
        }

        /// <inheritdoc/>
        public async Task ToggleFeedbackSoundOffAsync(string siteId)
        {
            string message = $"{{\"siteId\": \"{siteId}\"}}";
            await _client.PublishAsync(FeedbackToogleSoundOffQueueName, message);
        }

        #endregion

        #region IAudioServer

        /// <inheritdoc/>
        public IAudioServerOnFrameReceivedHandler OnFrameReceivedHandler { get; set; }

        #endregion

        #region IWakewordApi

        /// <inheritdoc/>
        public async Task ToggleWakewordOnAsync(string siteId)
        {
            string message = FormatSiteAndSessionMessage(siteId);
            await _client.PublishAsync(WakewordToogleWakewordOnQueueName, message);
        }

        /// <inheritdoc/>
        public async Task ToggleWakewordOffAsync(string siteId, string sessionId = null)
        {
            string message = FormatSiteAndSessionMessage(siteId, sessionId);
            await _client.PublishAsync(WakewordToogleWakewordOffQueueName, message);
        }

        /// <inheritdoc/>
        public async Task SendWakewordDetectedAsync(string wakewordId, WakewordDetectedMessage message)
        {
            var serializedMessage = Newtonsoft.Json.JsonConvert.SerializeObject(message);
            var messageQueueName = WakewordOnDetectedQueueName.Replace("#", wakewordId);
            await _client.PublishAsync(messageQueueName, serializedMessage);
        }

        /// <inheritdoc/>
        public async Task ToggleAsrOnAsync()
        {
            string message = string.Empty;
            await _client.PublishAsync(AsrToogleOnQueueName, message);
        }

        /// <inheritdoc/>
        public async Task ToggleAsrOffAsync()
        {
            string message = string.Empty;
            await _client.PublishAsync(AsrToogleOffQueueName, message);
        }

        /// <inheritdoc/>
        public async Task StartAsrToListen(string siteId, string sessionId = null)
        {
            string message = FormatSiteAndSessionMessage(siteId);
            await _client.PublishAsync(AsrStartListeningQueueName, message);
        }

        /// <inheritdoc/>
        public async Task StopAsrToListen(string siteId, string sessionId = null)
        {
            string message = FormatSiteAndSessionMessage(siteId);
            await _client.PublishAsync(AsrStopListeningQueueName, message);
        }

        #endregion

        #region Helper 

        /// <summary>
        /// Build a message consiting only of siteId and optional sessionId
        /// </summary>
        /// <param name="siteId">Id of the site</param>
        /// <param name="sessionId">Optional id of the session</param>
        /// <returns>build message</returns>
        public static string FormatSiteAndSessionMessage(string siteId, string sessionId = null)
        {
            string message = null;

            if (string.IsNullOrEmpty(sessionId))
            {
                message = $"{{\"siteId\": \"{siteId}\"}}";
            }
            else
            {
                message = $"{{\"siteId\": \"{siteId}\"}}, {{\"sessionId\": \"{sessionId}\"}}";
            }

            return message;
        }

        public static bool IsQueue(string queueNameWithWildCard, string reportedQueueName, out string wildCardContent)
        {
            wildCardContent = null;

            //If queue with wildcard is longer the reported queue then this won't match
            if(queueNameWithWildCard.Length > reportedQueueName.Length)
            {
                return false;
            }

            int indexOfWildCard = queueNameWithWildCard.IndexOf('#');

            //No wildcard then a simple equals it ok
            if (indexOfWildCard < 0)
            {
                return string.Equals(queueNameWithWildCard, reportedQueueName);
            }

            string startPart = null;
            string endPart = null;

            startPart = queueNameWithWildCard.Substring(0, indexOfWildCard);
            if (indexOfWildCard < queueNameWithWildCard.Length)
            {
                endPart = queueNameWithWildCard.Substring(indexOfWildCard + 1);
            }

            if(!reportedQueueName.StartsWith(startPart))
            {
                return false;
            }

            if(endPart != null && !reportedQueueName.EndsWith(endPart))
            {
                return false;
            }

            wildCardContent = reportedQueueName.Substring(indexOfWildCard);

            if(endPart != null)
            {
                wildCardContent = wildCardContent.Replace(endPart, "");
            }

            return true;
        }

        #endregion
    }
}
