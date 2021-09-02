package Controllers.ITools;

public interface IConstroller {
    boolean entre(String _user,String _pwd);
    String[] checkInformation();
    void changePasswd(String p_pwd,String n_pwd);
}
