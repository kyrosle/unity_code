package Information.user;

import Information.ITools.*;
import Information.People;

public class Student extends People  {

    protected String dormNum;
    protected String grade;
    public Performace performace ;

    public Student(String _name, int _ID, String _PhoneNum, String _dormNum, String _grade) {
        super(_name, _ID, _PhoneNum);
        dormNum=_dormNum;
        grade=_grade;
        userType=User_Type.STUDENT;
        performace = new Performace();
    }
    // 数据 复制 对象
    public Student(Student _user){
        super();
        name=_user.name;
        ID= _user.ID;
        PhoneNum = _user.PhoneNum;
        dormNum =_user.dormNum;
        grade = _user.grade;
        userType=_user.userType;
        performace = new Performace();
    }
    public Student(){
        userType=User_Type.STUDENT;
    }

    public String getGrade() {
        return grade;
    }

    public void setGrade(String grade) {
        this.grade = grade;
    }

    public String getDormNum() {
        return dormNum;
    }

    public void setDormNum(String dormNum) {
        this.dormNum = dormNum;
    }

    public Performace getPerformace() {
        return performace;
    }

    public void setPerformace(Performace performace) {
        this.performace = performace;
    }

    public String toString() {
        return  ID + " " +
                name + " " +
                PhoneNum + " " +
                dormNum + " " +
                grade + " " + performace.getA()+ " " + performace.getB()+ " " + performace.getC() ;
    }
}