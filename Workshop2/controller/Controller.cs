namespace workshop2 {

    class Controller {

            private MembersIndex _members;
            private FileHandler _fileHandler;
            private ViewHandler _viewHandler;
            private MainMenuController _mainMenuController;

            public Controller() {
                _members = new MembersIndex();
                _fileHandler = new FileHandler();
                _members.AddMultipleMembers(_fileHandler.LoadMemberList());
                _viewHandler = new ViewHandler(_members);
                _mainMenuController = new MainMenuController(_viewHandler);
            }

            public void runProgram() {
                _mainMenuController.ShowMainMenu();
                _fileHandler.SaveMemberList(_members.GetList());
            }
    }
}