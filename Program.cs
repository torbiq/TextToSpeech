using System;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Collections.Generic;

namespace TextToSpeech {
    public static class PhrazeManager {
        public enum PhrazeType {
            YouTubeStar,
            MatildaStupidVideo,
            ICanDoThisToo,
            INeedYourCamera,
            WhatWillYouShoot,
            HaveNotFiguredOut,
            ToMakeVideoPopular,
            InventedRecentlyMyGrandmother,
            ButIDontKnowHowToCook,
            AndThisIsGoodYouSaid,
            ChooseAReciepeToPrepare,
            ThisIsRecipe,
            HippiOmelette,
            HippiCookies,
            HippiEclairs,
            HippiJam,
            HippiCupcakes,
            HippiCake,
            HippiPancakes,
            HippiSmoothies,
            WillWeCookThisRecipe,
            HelloDearAudience,
            TodayWeWillPrepare,
            DadOmelette,
            DadCookies,
            DadEclairs,
            DadJam,
            DadCupcakes,
            DadCake,
            DadPancakes,
            DadSmoothies,
            Yep,
            Yeah,
            TuneSong,
            DontSleep,
            PressOnDad,
            Ahoy,
            Yeeeah,
            FinitaLaComedia,
            Tadam,
            OhYes,
            AllLikesAreOurs,
            OurVideoIsWonderful,
            VideoForMillionLikes,
            LetsSeeIt,
        }
        public enum Speaker {
            Hippi,
            Dad,
        }
        /// <summary>
        /// Path for debug sounds.
        /// </summary>
        private static string resourcesDebugPhrazesPath = "Sounds/DebugPhrazes/";
        /// <summary>
        /// Is it on debug.
        /// </summary>
        private static bool _isOnDebug = true;
        /// <summary>
        /// All phrazes dictionary.
        /// </summary>
        private static Dictionary<PhrazeType, Phraze> _phrazes = new Dictionary<PhrazeType, Phraze> {
        { PhrazeType.YouTubeStar,                       new Phraze("", Speaker.Hippi, PhrazeType.YouTubeStar,                       "It's time to become a Youtube star. Time to get famous!") },
        { PhrazeType.MatildaStupidVideo,                new Phraze("", Speaker.Hippi, PhrazeType.MatildaStupidVideo,                "Matilda made a stupid video, and millions of spectators have already seen it. And so many like it put her!") },
        { PhrazeType.ICanDoThisToo,                     new Phraze("", Speaker.Hippi, PhrazeType.ICanDoThisToo,                     "I can do that too. Even better! Now I'll take off such a cool movie that I'll get a billion views and likes!") },

        { PhrazeType.INeedYourCamera,                   new Phraze("", Speaker.Hippi, PhrazeType.INeedYourCamera,                   "Dad, I need your camera. I want to make a video and become a YouTube star!") },
        { PhrazeType.WhatWillYouShoot,                  new Phraze("", Speaker.Dad,   PhrazeType.WhatWillYouShoot,                  "Yes, eh? And what video will you shoot?") },
        { PhrazeType.HaveNotFiguredOut,                 new Phraze("", Speaker.Hippi, PhrazeType.HaveNotFiguredOut,                 "Mmm ... I have not figured out what yet, but I really, really want it.") },
        { PhrazeType.ToMakeVideoPopular,                new Phraze("", Speaker.Dad,   PhrazeType.ToMakeVideoPopular,                "To make the video popular, it should be funny or should tell something very interesting about what you know well.") },
        { PhrazeType.InventedRecentlyMyGrandmother,     new Phraze("", Speaker.Hippi, PhrazeType.InventedRecentlyMyGrandmother,     "Invented! Recently, my grandmother taught me how to cook. And I'll take off my culinary show! And the main character in it will be you, Dad.") },
        { PhrazeType.ButIDontKnowHowToCook,             new Phraze("", Speaker.Dad,   PhrazeType.ButIDontKnowHowToCook,             "But I do not know how to cook at all!") },
        { PhrazeType.AndThisIsGoodYouSaid,              new Phraze("", Speaker.Hippi, PhrazeType.AndThisIsGoodYouSaid,              "And this is good! You yourself said that the video should be funny.") },
        { PhrazeType.ChooseAReciepeToPrepare,           new Phraze("", Speaker.Hippi, PhrazeType.ChooseAReciepeToPrepare,           "Choose the recipe that we will prepare live!") },

        { PhrazeType.ThisIsRecipe,                      new Phraze("", Speaker.Hippi, PhrazeType.ThisIsRecipe,                      "This is recipe of ") },

        { PhrazeType.HippiOmelette,                     new Phraze("", Speaker.Hippi, PhrazeType.HippiOmelette,                     "Omelette") },
        { PhrazeType.HippiCookies,                      new Phraze("", Speaker.Hippi, PhrazeType.HippiCookies,                      "Cookies") },
        { PhrazeType.HippiEclairs,                      new Phraze("", Speaker.Hippi, PhrazeType.HippiEclairs,                      "Eclairs") },
        { PhrazeType.HippiJam,                          new Phraze("", Speaker.Hippi, PhrazeType.HippiJam,                          "Jam") },
        { PhrazeType.HippiCake,                         new Phraze("", Speaker.Hippi, PhrazeType.HippiCake,                         "Cake") },
        { PhrazeType.HippiPancakes,                     new Phraze("", Speaker.Hippi, PhrazeType.HippiPancakes,                     "Pancakes") },
        { PhrazeType.HippiSmoothies,                    new Phraze("", Speaker.Hippi, PhrazeType.HippiSmoothies,                    "Smoothies") },

        { PhrazeType.WillWeCookThisRecipe,              new Phraze("", Speaker.Hippi, PhrazeType.WillWeCookThisRecipe,              "We will cook this recipe?") },

        { PhrazeType.HelloDearAudience,                 new Phraze("", Speaker.Dad,   PhrazeType.HelloDearAudience,                 "Hello, dear audience. On air, the Culinary Hippo Show!") },
        { PhrazeType.TodayWeWillPrepare,                new Phraze("", Speaker.Dad,   PhrazeType.TodayWeWillPrepare,                "Today we will prepare...") },

        { PhrazeType.DadOmelette,                       new Phraze("", Speaker.Dad,   PhrazeType.DadOmelette,                       "Ordinary eggs") },
        { PhrazeType.DadCookies,                        new Phraze("", Speaker.Dad,   PhrazeType.DadCookies,                        "Fragrant friable cookies") },
        { PhrazeType.DadEclairs,                        new Phraze("", Speaker.Dad,   PhrazeType.DadEclairs,                        "Delicious eclairs") },
        { PhrazeType.DadJam,                            new Phraze("", Speaker.Dad,   PhrazeType.DadJam,                            "Sweet fruit and berry preserves") },
        { PhrazeType.DadCupcakes,                       new Phraze("", Speaker.Dad,   PhrazeType.DadCupcakes,                       "Appetizing cupcakes with crispy crust") },
        { PhrazeType.DadCake,                           new Phraze("", Speaker.Dad,   PhrazeType.DadCake,                           "A gorgeous birthday cake") },
        { PhrazeType.DadPancakes,                       new Phraze("", Speaker.Dad,   PhrazeType.DadPancakes,                       "Thin wonderful pancakes") },
        { PhrazeType.DadSmoothies,                      new Phraze("", Speaker.Dad,   PhrazeType.DadSmoothies,                      "Useful fruit ice cream and smoothies") },

        { PhrazeType.Yep,                               new Phraze("", Speaker.Dad,   PhrazeType.Yep,                               "Yep!") },
        { PhrazeType.Yeah,                              new Phraze("", Speaker.Dad,   PhrazeType.Yeah,                              "Yeah!") },

        { PhrazeType.TuneSong,                          new Phraze("", Speaker.Dad,   PhrazeType.TuneSong,                          "Tada daaam tada dam ta da da da da da dam!") },

        { PhrazeType.DontSleep,                         new Phraze("", Speaker.Hippi, PhrazeType.DontSleep,                         "Dad, do not go to sleep!") },
        { PhrazeType.PressOnDad,                        new Phraze("", Speaker.Hippi, PhrazeType.PressOnDad,                        "Press on dad to wake up") },

        { PhrazeType.Ahoy,                              new Phraze("", Speaker.Dad,   PhrazeType.Ahoy,                              "Ahoy!") },
        { PhrazeType.Yeeeah,                            new Phraze("", Speaker.Dad,   PhrazeType.Yeeeah,                            "Ye-e-e-e-eah!") },
        { PhrazeType.FinitaLaComedia,                   new Phraze("", Speaker.Dad,   PhrazeType.FinitaLaComedia,                   "Finita la comedia!") },
        { PhrazeType.Tadam,                             new Phraze("", Speaker.Dad,   PhrazeType.Tadam,                             "Ta-dam!") },
        { PhrazeType.OhYes,                             new Phraze("", Speaker.Dad,   PhrazeType.OhYes,                             "Oh yes!") },

        { PhrazeType.AllLikesAreOurs,                   new Phraze("", Speaker.Hippi, PhrazeType.AllLikesAreOurs,                   "It turned out great movie! All likes are ours!") },
        { PhrazeType.OurVideoIsWonderful,               new Phraze("", Speaker.Hippi, PhrazeType.OurVideoIsWonderful,               "Our video is wonderful! The audience will be delighted!") },
        { PhrazeType.VideoForMillionLikes,              new Phraze("", Speaker.Hippi, PhrazeType.VideoForMillionLikes,              "This video for one hundred million likes!") },

        { PhrazeType.LetsSeeIt,                         new Phraze("", Speaker.Hippi, PhrazeType.LetsSeeIt,                         "Let's watch our video on YouTube channel.") },
    };
        /// <summary>
        /// All phrazes dictionary.
        /// </summary>
        public static Dictionary<PhrazeType, Phraze> phrazes {
            get {
                return _phrazes;
            }
        }
        /// <summary>
        /// Phraze info.
        /// </summary>
        public class Phraze {
            /// <summary>
            /// Prototype name of file. (e.g. hp-1, mh-46).
            /// </summary>
            public string prototypeName { get; private set; }
            /// <summary>
            /// Narrator.
            /// </summary>
            public Speaker speaker { get; private set; }
            /// <summary>
            /// Text to be displayed for debug.
            /// </summary>
            public string debugText { get; private set; }
            /// <summary>
            /// Phraze type.
            /// </summary>
            public PhrazeType phrazeType { get; private set; }
            /// <summary>
            /// Naming of file in test phrazes folder.
            /// </summary>
            public string testGeneratedName { get; private set; }
            
            /// <summary>
            /// Constructor for phraze.
            /// </summary>
            /// <param name="prototypeName">Prototype name of file. (e.g. hp-1, mh-46).</param>
            /// <param name="speaker">Narrator.</param>
            /// <param name="phrazeType">Phraze type from enum.</param>
            /// <param name="debugText">Text to be shown for debug.</param>
            /// <param name="testGeneratedName">If empty, loads phraze by phrazeType.ToString().</param>
            public Phraze(string prototypeName, Speaker speaker, PhrazeType phrazeType, string debugText, string testGeneratedName = "") {
                this.prototypeName = prototypeName;
                this.speaker = speaker;
                this.phrazeType = phrazeType;
                this.debugText = debugText;
                this.testGeneratedName = testGeneratedName == "" ? phrazeType.ToString() : testGeneratedName;
            }
        }
    }

    class Program {
        static void Main(string[] args) {
            // Initialize a new instance of the SpeechSynthesizer.
            var synth1 = new SpeechSynthesizer();
            foreach (var voice in synth1.GetInstalledVoices()) {
                Console.WriteLine(voice.VoiceInfo.Name);
            }

            foreach (var phraze in PhrazeManager.phrazes) {
                using (SpeechSynthesizer synth = new SpeechSynthesizer()) {
                    switch (phraze.Value.speaker) {
                        case PhrazeManager.Speaker.Dad: 
                            //.SelectVoice("Microsoft Zira Desktop");
                            //break;
                        case PhrazeManager.Speaker.Hippi:
                            //synth.SelectVoice("Microsoft Irina Desktop");
                            //break;
                        default:
                            synth.SelectVoice("Microsoft Zira Desktop");
                            break;
                    }
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\TestVoices\";
                    string name = phraze.Key.ToString() + ".wav";
                    path += name;

                    synth.SetOutputToWaveFile(path, new SpeechAudioFormatInfo(16000, AudioBitsPerSample.Eight, AudioChannel.Mono));
                    synth.SpeakCompleted += delegate {
                        Console.WriteLine("Writing to " + path + " done.");
                    };
                    Console.WriteLine("Speaking: " + phraze.Value.debugText);
                    synth.Speak(phraze.Value.debugText);
                }
            }
            Console.WriteLine("Wait for end");
            Console.ReadKey();
        }
    }
}