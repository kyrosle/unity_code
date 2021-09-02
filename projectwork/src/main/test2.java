package main;

import Controllers.ControllerManager;
import Controllers.ITools.IStudentController;
import Information.AccountManager;
import Information.People;
import Information.user.Student;
import com.alibaba.fastjson.JSON;
import gui.EnterJfrom;

import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;

public class test2 {
    public static void main(String[] args) {
        new AccountManager();
        AccountManager.instance.Awake();
        AccountManager.instance.Start();
        new ControllerManager();
        EnterJfrom jf =new EnterJfrom();
        jf.setVisible(true);


//
//
//        String str = ControllerManager.instance.SaveData(AccountManager.instance.StudentsList);
//        System.out.println(str);


//        ArrayList<Student> list = new ArrayList<>();
//        list = (ArrayList<Student>) JSON.parseArray(str, Student.class);


//        StringBuffer sb = new StringBuffer(str);
//
//        try {
//            FileWriter fw = new FileWriter("./SaveFiles/test.txt");
//            fw.write(sb.toString());
//            fw.close();
//
//        }catch (IOException e){
//            e.printStackTrace();
//        }

//        ControllerManager.instance.SaveToText();

//        try{
//            ControllerManager.instance.LoadFromText();
//            for (Student stu:
//                    AccountManager.instance.StudentsList
//                 ) {
//                System.out.println(stu);
//            }
//        } catch (Exception e) {
//            e.printStackTrace();
//        }
    }
}
