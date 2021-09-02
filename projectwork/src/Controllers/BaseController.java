package Controllers;

import Controllers.ITools.IConstroller;
import Information.People;


public abstract class BaseController implements IConstroller {
    public People user = ControllerManager.instance.user;
    @Override
    public boolean entre(String _user,String _pwd) {
        if(user.GetUser() == null || user.GetPwd() == null ){
            System.out.println("user has not registered!");
            return false;
        }

        String user_name = user.GetUser();
        String user_pwd = user.GetPwd();

        if(_user.equals(user_name)){
            if(_pwd.equals(user_pwd)){
                return true;
            }else
                System.out.println("passwd no match!");
        }else
            System.out.println("no exist user name!");
        return false;
    }

    @Override
    public void changePasswd(String p_pwd,String n_pwd) {
        if(p_pwd.equals(user.GetPwd())){
            user.SetPwd(n_pwd);
        }else
            System.out.println("error passwd");
    }
}
