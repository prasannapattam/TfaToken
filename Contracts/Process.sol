
pragma solidity ^0.4.11;

contract Process {

    struct Instance {
        string FormCode;
        string Comments;
        string Approver;
    }

    mapping(string => Instance) instances;         

    function Initiate(string FormCode, string Comments, string Approver) public {
        instances[FormCode] = Instance({ FormCode: FormCode, Comments: Comments,  Approver: Approver});
    }

    function Start(string FormCode, string Comments, string Approver) public {
        instances[FormCode] = Instance({ FormCode: FormCode, Comments: Comments,  Approver: Approver});
    }

    function Created(string FormCode, string Comments, string Approver) public {
        instances[FormCode] = Instance({ FormCode: FormCode, Comments: Comments,  Approver: Approver});
    }

    function Submitted(string FormCode, string Comments, string Approver) public {
        instances[FormCode] = Instance({ FormCode: FormCode, Comments: Comments,  Approver: Approver});
    }

    function RequestCompleted(string FormCode, string Comments, string Approver) public {
        instances[FormCode] = Instance({ FormCode: FormCode, Comments: Comments,  Approver: Approver});
    }

}
