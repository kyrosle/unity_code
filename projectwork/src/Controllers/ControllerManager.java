package Controllers;

import Controllers.userController.*;
import Information.*;
import Information.ITools.User_Type;
import Information.user.*;
import com.alibaba.fastjson.JSON;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileWriter;
import java.io.IOException;
import java.lang.reflect.Type;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;

public class ControllerManager {
    static public ControllerManager instance;
    // 操作用户数据
    public People user;

    // 用户类型
    public User_Type userType;

    // 用户适配的功能
    public BaseController controller;

    public ControllerManager(){
        Awake();
    }
    // 单例模式
    public void Awake(){
        if(instance == null)
            instance=this;
        AccountManager.instance.userMap.put("root","123");
    }


    // 目前操作者注册
    public void Register(User_Type user_type,People _user){
        userType = user_type;
        switch (user_type){
            case STUDENT :
                user =new Student((Student) _user);
                controller = new StudentController();
                break;
            case TEACHER:
                user = new Teacher((Teacher)_user);
                controller = new TeacherController();
                break;
            case MANAGER:
                user = new Manager((Manager) _user );
                controller= new ManagerController();
                break;
        }
    }

    // 数据保存和读入
    public <T> String SaveData(ArrayList<T> _list){
        String s_str = JSON.toJSONString(_list);
        return s_str;
    }

    // 无法修复的 读取 null
    public <T extends People> ArrayList<T> loadData(String str) {
        ArrayList<T> list = (ArrayList<T>) JSON.parseArray(str,People.class);
        return list;
    }

    // 自动 保存 存档
    public void SaveToText(){
        String stu_str,tea_str,man_str;
        stu_str = SaveData(AccountManager.instance.StudentsList);
        tea_str = SaveData(AccountManager.instance.TeachersList);
        man_str = SaveData(AccountManager.instance.ManagersList);
       try {
           FileWriter fw = new FileWriter("./SaveFiles/test.txt");

           fw.write(stu_str);
           fw.write('\n');
           fw.write(tea_str);
           fw.write('\n');
           fw.write(man_str);
           fw.write('\n');

           fw.close();

       }catch (IOException e){
            e.printStackTrace();
       }
    }

    // 自动 获取 存档
    public void LoadFromText()throws Exception{
        File file= new File("./SaveFiles/test.txt");
        if(!file.exists()){
            System.out.println("error file");
            return;
        }

        FileInputStream inputStream = new  FileInputStream(file);
        int length = inputStream.available();
        String stu_str,tea_str,man_str;
        byte bytes[] = new byte[length];

        inputStream.read(bytes);
        String get_str = new String(bytes,StandardCharsets.UTF_8);

        String[] str= new String[3];
        str = get_str.split("\n");

//        inputStream.read(bytes);
//        stu_str = new String(bytes, StandardCharsets.UTF_8);
        stu_str = str[0];

//        inputStream.read(bytes);
//        tea_str = new String(bytes, StandardCharsets.UTF_8);
        tea_str = str[1];

//        inputStream.read(bytes);
//        man_str = new String(bytes, StandardCharsets.UTF_8);
        man_str = str[2];

        AccountManager.instance.StudentsList = new ArrayList<Student>(Load_S_Data(stu_str));
        AccountManager.instance.TeachersList = new ArrayList<Teacher>(Load_T_Data(tea_str));
        AccountManager.instance.ManagersList = new ArrayList<Manager>(Load_M_Data(man_str));
    }
    public ArrayList<Student> Load_S_Data(String str){
        return (ArrayList<Student>) JSON.parseArray(str,Student.class);
    }
    public ArrayList<Teacher> Load_T_Data(String str){
        return (ArrayList<Teacher>) JSON.parseArray(str,Teacher.class);
    }
    public ArrayList<Manager> Load_M_Data(String str){
        return (ArrayList<Manager>) JSON.parseArray(str,Manager.class);
    }
}
