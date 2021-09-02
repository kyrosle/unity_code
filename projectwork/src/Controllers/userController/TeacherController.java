package Controllers.userController;

import Controllers.BaseController;
import Controllers.ITools.ITeacherController;
import Information.AccountManager;
import Information.ITools.Performace;
import Information.ITools.User_Type;
import Information.user.Student;
import Information.user.Teacher;

import java.util.ArrayList;
import java.util.Map;

public class TeacherController extends BaseController implements  ITeacherController {
    Teacher teacher = null;
    public TeacherController(){
        if(user instanceof ITeacherController)
            teacher = (Teacher) user;
    }
    @Override
    public void Type_in_Student_User_Pwd(String s_user, String s_pwd) {
        ArrayList<Student> list = AccountManager.instance.StudentsList;

        Student t_stu = new Student();
        t_stu.SetUser(s_user);
        t_stu.SetPwd(s_pwd);

        if (AccountManager.instance.userMap.containsKey(s_user)) {
            System.out.println("replete user");
            return;
        }

        AccountManager.instance.userMap.put(s_user,s_user);
        AccountManager.instance.typeMap.put(s_user,User_Type.STUDENT);

        list.add(t_stu);
    }

    @Override
    public void Type_in_Student_Sorce(String s_user, Performace sorce) {

        if (!AccountManager.instance.userMap.containsKey(s_user)){
            System.out.println("no this user");
            return;
        }

        Student stu = AccountManager.instance.SearchUser(AccountManager.instance.StudentsList,
                s_user);

        if(stu == null) {
            System.out.println("no get");
            return;
        }

        stu.setPerformace(sorce);
    }

    @Override
    public void Check_Student_Sorce(String s_user) {
        if (!AccountManager.instance.userMap.containsKey(s_user)){
            System.out.println("no this user");
            return;
        }

        Student stu = AccountManager.instance.SearchUser(AccountManager.instance.StudentsList,
                s_user);

        System.out.println(stu.getPerformace());
    }

    @Override
    public void Change_Student_Sorce(String s_user,Performace performace) {
        if (!AccountManager.instance.userMap.containsKey(s_user)){
            System.out.println("no this user");
            return;
        }

        Student stu = AccountManager.instance.SearchUser(AccountManager.instance.StudentsList,
                s_user);

        stu.setPerformace(performace);
    }

    @Override
    public void Check_all_Student_Sorce() {
        ArrayList<Student> list = AccountManager.instance.StudentsList;
        for (var stu :
                list) {
            System.out.println(stu);
        }
    }

    @Override
    public String[] checkInformation() {
        String info = teacher.toString();
        String[] infos = info.split(" ");
        return infos;
    }
}
