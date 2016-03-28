using KitchenSink.Module;

namespace KitchenSink {
    partial class TextPage : Partial {

        protected override void OnData()
        {
            base.OnData();

            var console = NinjectKernel.Instance.GetModule<IConsoleModule>();
            console.WriteOutput("some output");
        }

        public string CalculatedNameReaction {
            get {
                if (Name == "") {
                    return "What's your name?";
                }
                else {
                    return "Hi, " + Name + "!";
                }
            }
        }

        public string CalculatedNameLiveReaction {
            get {
                if (NameLive == "") {
                    return "What's your name?";
                }
                else {
                    return "Hi, " + NameLive + "!";
                }
            }
        }
    }
}
