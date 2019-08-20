# SDO.SnipsAI.Client

SDO.SnipsAI.Client is an **INOFFICIAL** client library for [snips.ai](http://snips.ai) targeting .NET Standard 2.0.

It uses MQTTnet to connect to mosquitto MQTT server used by the snips.ai infrastructure and implements the hermes protocol.

## Used Libraries

 * [MQTTnet](https://github.com/chkr1011/MQTTnet)
 * [NewtonSoft Json](https://www.newtonsoft.com/json)
 * [JsonSubTypes](https://github.com/manuc66/JsonSubTypes)

## Features

 * Implements the dialog api [Link](https://docs.snips.ai/reference/dialogue)
 * Support of all slot types [Link](https://docs.snips.ai/articles/platform/dialog/slot-types)

## How to start

 * Create your app and intents using the snips.ai webinterface
 * Install the app on the raspberry pi using sam
 * Install .NET Core 2.2+ on the rasperry pi
 * Create a console application targeting .NET Core 2.2
   * Add the client as a reference (TODO: Nuget Package)
   * Add the dependencies (MQTTnet, Newtonsoft Json, JsonSubTypes) 
 * Create a class which implements IDialog

        public class TestDialog : IDialog
        {
            private ISnipsApi _snipsApi;

            public string InitialIntendName => "sdoempke:Greeting";

            public async Task OnIntentAsync(IntentMessage intent, Session session)
            {
                //Check the Slots in intent
                await _snipsApi.EndSessionAsync(intent.SessionId, "Test is Done!");
            }

            public void OnRegistration(ISnipsApi snipsApi)
            {
                _snipsApi = snipsApi;
            }

            public void OnUnregistration()
            {
            }
        }

 * Register this class and connect to the Mosquitto server

        public static void Main(string[] args) 
        {
            var snipsClient = new SnipsClient();

            snipsClient.RegisterDialog(new TestDialog());
            snipsClient.Connect("127.0.0.1")

            Console.ReadLine();
        }

 * Start the application on the raspberry pi or on your development system (check for the correct urls) 

## License

MIT License

SDO.SnipsAI.Client Copyright (c) 2019 Steven Doempke

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.