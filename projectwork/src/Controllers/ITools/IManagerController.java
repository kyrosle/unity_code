package Controllers.ITools;

import Information.user.Teacher;

public interface IManagerController {
    void Type_in_Teacher_User_Pwd(String t_user,String t_pwd);
    void Change_Teacher_Information(String t_usr, Teacher teacher);
    void Delete_Teacher_Information(String t_usr);
    void CheckSelf_Information();
    void Check_all_Teachers();
    Teacher Search_Teacher(String t_usr);
}
