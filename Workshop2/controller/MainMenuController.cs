using System;
using System.Collections.Generic;
using System.Linq;

namespace workshop2 {

    class MainMenuController {

        private ViewHandler _viewHandler;
        private HelpFunctions hf = new HelpFunctions();
        public MainMenuController(ViewHandler viewHandler) {
            _viewHandler = viewHandler;
        }

        public void ShowMainMenu()
        {
            int value;
            List<string> options = _viewHandler.GetMainMenuOptions();
            do
            {        
                hf.ChangeColorBlueAddLine();
                _viewHandler.PrintWelcome();
                hf.ResetColorAddLine();
                hf.printOptions(options);
                value = hf.GetValueFromUser(options.Count);
                Console.Clear();
                if (value == 1)
                {
                    _viewHandler.ShowListCompactView();
                }
                if (value == 2)
                {
                    _viewHandler.ShowListVerboseView();
                }
                if (value == 3)
                {
                    _viewHandler.ShowAddMemberView();
                }
                if (value == 4)
                {
                    _viewHandler.ShowDeleteView();
                }
                if (value == 5)
                {
                    _viewHandler.ShowViewMemberView();
                }
                if (value == 6)
                {
                    _viewHandler.ShowEditView();
                }
            } while (value != 0);
            hf.ChangeColorRedAddLine();
            Console.WriteLine("Application Terminated.");
            hf.ResetColorAddLine();
        }
    }
}