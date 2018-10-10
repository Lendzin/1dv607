namespace workshop2 {

    class Controller {

            private MembersIndex _members;
            private FileHandler _fileHandler;
            private ViewHandler _viewHandler;

            public Controller() {
                _members = new MembersIndex();
                _fileHandler = new FileHandler();
                _members.AddMultipleMembers(_fileHandler.LoadMemberList());
                _viewHandler = new ViewHandler(_members);
            }

            public void runProgram() {
                _viewHandler.StartView();
                _fileHandler.SaveMemberList(_members.GetList());
            }
    }
}