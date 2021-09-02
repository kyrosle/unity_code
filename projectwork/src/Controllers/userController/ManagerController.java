package Controllers.userController;

import Controllers.BaseController;
import Controllers.ITools.IManagerController;
import Information.AccountManager;
import Information.ITools.User_Type;
import Information.user.Manager;
import Information.user.Teacher;

import java.lang.reflect.Array;
import java.util.ArrayList;

public class ManagerController extends BaseController implements IManagerController {
    Manager manager = (Manager) user;
    // 输入 老师 用户名 密码
    @Override
    public void Type_in_Teacher_User_Pwd(String t_user, String t_pwd) {
        Teacher teacher = new Teacher();
        teacher.SetUser(t_user);
        teacher.SetPwd(t_pwd);

        if(AccountManager.instance.userMap.containsKey(t_user)){
            System.out.println("replete user");
            return;
        }

        AccountManager.instance.userMap.put(t_user, t_pwd);
        AccountManager.instance.typeMap.put(t_user,User_Type.TEACHER);

        AccountManager.instance.TeachersList.add(teacher);
    }

    // 修改 老师 信息
    @Override
    public void Change_Teacher_Information(String t_usr,Teacher info) {
        if(!AccountManager.instance.userMap.containsKey(t_usr)){
            System.out.println("no this user");
            return;
        }
        Teacher teacher = AccountManager.instance.SearchUser(AccountManager.instance.TeachersList,
                t_usr);

        teacher.SetTeacher(info);
    }

    // 删除 老师 信息
    @Override
    public void Delete_Teacher_Information(String t_usr) {
        if(!AccountManager.instance.userMap.containsKey(t_usr)){
            System.out.println("not this user");
            return;
        }
        Iterable<Teacher> it = AccountManager.instance.TeachersList;
        for(;it.iterator().hasNext();){
            Teacher s=it.iterator().next();
            if (s.getName().equals(t_usr)){
                System.out.println("delete successed");
                it.iterator().remove();
            }
        }
    }

    // 查看自己信息
    @Override
    public void CheckSelf_Information() {
        System.out.println(manager);
    }

    // 查看 所有 老师信息
    @Override
    public void Check_all_Teachers() {
        ArrayList<Teacher>list = AccountManager.instance.TeachersList;
        for (var s :
                list) {
            System.out.println(s);
        }
    }

    // 查找某个老师
    @Override
    public Teacher Search_Teacher(String t_usr) {
       return AccountManager.instance.SearchUser(AccountManager.instance.TeachersList,
               t_usr);
    } @Override
    public String[] checkInformation() {
        String info =manager.toString();

        String[] infos = info.split(" ");

       return infos;
    }
}
