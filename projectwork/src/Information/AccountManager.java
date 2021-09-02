package Information;

import Information.ITools.User_Type;
import Information.user.Manager;
import Information.user.Student;
import Information.user.Teacher;

import java.util.*;

public class AccountManager {
    static public AccountManager instance;
    //testing:
    //TODO: 对文件读入信息 json
    public ArrayList<Student> StudentsList = new ArrayList<Student>();
    public ArrayList<Teacher> TeachersList = new ArrayList<Teacher>();
    public ArrayList<Manager> ManagersList = new ArrayList<Manager>();
    // 匹配密码
    public Map<String, String> userMap = new HashMap<>();
    // 匹配用户类别
    public Map<String, User_Type>typeMap= new HashMap<>();

    public AccountManager(){
        Awake();
        Start();
    }

    public void Awake(){
        if(instance == null)
            instance =this;
    }
    public void Start(){
        StudentsList.add(new Student("kyros",1,"123","169","university"));
        TeachersList.add(new Teacher("teacher",1,"233"));
        ManagersList.add(new Manager("manager",1,"886"));
    }

    public <T extends People> T SearchUser(ArrayList<T> list,String _user){
        T end = null;
        for (T man :
                list) {
            if(man.GetUser().equals(_user)){
                end = man;
                break;
            }
        }
        return end;
    }
}
