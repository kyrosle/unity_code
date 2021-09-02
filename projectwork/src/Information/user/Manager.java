package Information.user;

import Information.AccountManager;
import Information.ITools.*;
import Information.People;

public class Manager extends People  {
    public Manager(String _name, int _ID, String _PhoneNum) {
        super(_name, _ID, _PhoneNum);
        userType=User_Type.MANAGER;
        // TODO: 最终delete
        AccountManager.instance.userMap.put(_name,"123");
        AccountManager.instance.typeMap.put(_name,User_Type.MANAGER);
    }
    public Manager(Manager _user){
        super();
        name=_user.name;
        ID= _user.ID;
        PhoneNum = _user.PhoneNum;
        userType=_user.userType;
    }
    public String toStirng() {
        return  ID + " " +
                name + " " +
                PhoneNum ;
    }
}
