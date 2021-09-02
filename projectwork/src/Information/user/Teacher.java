package Information.user;

import Information.ITools.*;
import Information.People;

public  class Teacher extends People {

    public Teacher(String _name, int _ID, String _PhoneNum) {
        super(_name, _ID, _PhoneNum);
        userType=User_Type.TEACHER;
    }
    public Teacher(Teacher _user){
        super();
        name=_user.name;
        ID= _user.ID;
        PhoneNum = _user.PhoneNum;
        userType=_user.userType;
    }
    public void SetTeacher(Teacher _user){
        name=_user.name;
        ID= _user.ID;
        PhoneNum = _user.PhoneNum;
        userType=_user.userType;
    }
    public Teacher(){
        userType=User_Type.TEACHER;
    }

    public String toStirng() {
        return  ID + " " +
                name + " " +
                PhoneNum ;
    }
}
