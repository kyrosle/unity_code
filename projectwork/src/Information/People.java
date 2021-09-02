package Information;

import Information.ITools.User_Type;

public abstract class People {
    protected String name;
    protected int ID;
    protected String PhoneNum;
    public User_Type userType;

    private String user = null;
    private String pwd = null;
    public People(){};
    public People(String _name,int _ID,String _PhoneNum){
        name=_name;
        ID=_ID;
        PhoneNum=_PhoneNum;
    }

    public int getID() {
        return ID;
    }

    public void setID(int ID) {
        this.ID = ID;
    }

    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }
    public String getPhoneNum() {
        return PhoneNum;
    }
    public void setPhoneNum(String phoneNum) {
        PhoneNum = phoneNum;
    }


    //  密码
    public void SetUser(String _user){
        user=_user;
    }

    public String GetUser(){
        return user;
    }

    public void SetPwd(String _pwd){
        pwd =_pwd;
    }

    public String GetPwd(){
        return pwd;
    }
}
