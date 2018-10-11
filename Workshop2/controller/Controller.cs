namespace workshop2 {

    class Controller {

            private MembersIndex _members;
            private FileHandler _fileHandler;
            private ViewHandler _viewHandler;
            private MemberRenderer _memberRenderer;
            private MainMenuController _mainMenuController;

            public Controller() {
                _members = new MembersIndex();
                _fileHandler = new FileHandler();
                _members.AddMultipleMembers(_fileHandler.LoadMemberList());
                _memberRenderer = new MemberRenderer(_members);
                _viewHandler = new ViewHandler(_members, _memberRenderer);
                _mainMenuController = new MainMenuController(_viewHandler);
            }

            public void runProgram() {
                _mainMenuController.ShowMainMenu();
                _fileHandler.SaveMemberList(_members.GetList());
            }
    }
}