package Controllers.ITools;

import Information.ITools.Performace;

public interface ITeacherController {
   void Type_in_Student_User_Pwd(String s_user,String s_pwd);
   void Type_in_Student_Sorce(String s_user, Performace sorce);
   void Check_Student_Sorce(String s_user);
   void Change_Student_Sorce(String s_user,Performace performace);
   void Check_all_Student_Sorce();
}
