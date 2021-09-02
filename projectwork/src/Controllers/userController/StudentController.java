package Controllers.userController;

import Controllers.BaseController;
import Controllers.ITools.IStudentController;
import Information.user.Student;

public class StudentController extends BaseController implements  IStudentController {
    // 向下转型
    Student stu = (Student) user;
    // 查看成绩
    @Override
    public String checkSorce() {
        String stu_sorce = stu.getPerformace().toString();
        return stu_sorce;
    }

    @Override
    public String[] checkInformation() {
        String info = stu.toString();

        String[] infos = info.split(" ");

       return infos;
    }
}
