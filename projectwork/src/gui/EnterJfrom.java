/*
 * Created by JFormDesigner on Thu Aug 19 16:44:15 CST 2021
 */

package gui;

import Controllers.ControllerManager;
import Controllers.userController.ManagerController;
import Controllers.userController.StudentController;
import Controllers.userController.TeacherController;
import Information.AccountManager;
import Information.ITools.User_Type;

import java.awt.*;
import java.awt.event.*;
import java.util.ArrayList;
import javax.swing.*;

/**
 * @author kyros
 */
public class EnterJfrom extends JFrame {
    public EnterJfrom() {
        initComponents();
    }


    private void button1ActionPerformed(ActionEvent e) {
        // TODO add your code here

        String usr,pwd;
        usr = textField1.getText();
        pwd = textField2.getText();

        if(AccountManager.instance.userMap.containsKey(usr)){
            if(pwd.equals(AccountManager.instance.userMap.get(usr))){
                //TODO: 换界面
                User_Type user_type = AccountManager.instance.typeMap.get(usr);

                switch (user_type)
                {
                    case STUDENT:
                        ControllerManager.instance.controller = new StudentController();
                        JFrame sf = new StudentJfrom();
                        sf.setVisible(true);
                        break;
                    case TEACHER:
                        ControllerManager.instance.controller = new TeacherController();
                        JFrame tf = new TeacherJfrom();
                        tf.setVisible(true);
                        break;
                    case MANAGER:
                        ControllerManager.instance.controller = new ManagerController();
                        JFrame mf = new ManagerJfrom();
                        mf.setVisible(true);
                        break;
                }
                setVisible(false);
            }
            else
                textField3.setText("密码错误");
        }else
            textField3.setText("不存在用户");
    }




    private void initComponents() {
        // JFormDesigner - Component initialization - DO NOT MODIFY  //GEN-BEGIN:initComponents
        center = new JPanel();
        label1 = new JLabel();
        panel5 = new JPanel();
        label3 = new JLabel();
        label4 = new JLabel();
        panel6 = new JPanel();
        textField1 = new JTextField();
        textField2 = new JTextField();
        button1 = new JButton();
        panel7 = new JPanel();
        panel1 = new JPanel();
        panel2 = new JPanel();
        panel3 = new JPanel();
        textField3 = new JTextField();
        panel4 = new JPanel();

        //======== this ========
        setMinimumSize(new Dimension(400, 300));
        var contentPane = getContentPane();
        contentPane.setLayout(new BorderLayout(40, 40));

        //======== center ========
        {
            center.setLayout(new BorderLayout(40, 100));

            //---- label1 ----
            label1.setText("\u5b66\u751f\u6210\u7ee9\u7ba1\u7406\u7cfb\u7edf");
            label1.setHorizontalAlignment(SwingConstants.CENTER);
            label1.setFont(label1.getFont().deriveFont(label1.getFont().getSize() + 15f));
            center.add(label1, BorderLayout.NORTH);

            //======== panel5 ========
            {
                panel5.setLayout(new GridLayout(2, 0));

                //---- label3 ----
                label3.setText("\u7528\u6237\u540d");
                label3.setFont(label3.getFont().deriveFont(label3.getFont().getSize() + 10f));
                label3.setHorizontalTextPosition(SwingConstants.CENTER);
                label3.setHorizontalAlignment(SwingConstants.CENTER);
                label3.setVerticalAlignment(SwingConstants.TOP);
                panel5.add(label3);

                //---- label4 ----
                label4.setText("\u5bc6\u7801");
                label4.setFont(label4.getFont().deriveFont(label4.getFont().getSize() + 10f));
                label4.setHorizontalTextPosition(SwingConstants.CENTER);
                label4.setVerticalAlignment(SwingConstants.BOTTOM);
                label4.setHorizontalAlignment(SwingConstants.CENTER);
                panel5.add(label4);
            }
            center.add(panel5, BorderLayout.WEST);

            //======== panel6 ========
            {
                panel6.setLayout(new GridLayout(2, 0, 40, 60));
                panel6.add(textField1);
                panel6.add(textField2);
            }
            center.add(panel6, BorderLayout.CENTER);

            //---- button1 ----
            button1.setText("\u767b\u9646");
            button1.setFont(button1.getFont().deriveFont(button1.getFont().getSize() + 5f));
            button1.addActionListener(e -> button1ActionPerformed(e));
            center.add(button1, BorderLayout.SOUTH);

            //======== panel7 ========
            {
                panel7.setLayout(new BorderLayout());
            }
            center.add(panel7, BorderLayout.EAST);
        }
        contentPane.add(center, BorderLayout.CENTER);

        //======== panel1 ========
        {
            panel1.setLayout(new BorderLayout());
        }
        contentPane.add(panel1, BorderLayout.WEST);

        //======== panel2 ========
        {
            panel2.setLayout(new BorderLayout());
        }
        contentPane.add(panel2, BorderLayout.NORTH);

        //======== panel3 ========
        {
            panel3.setLayout(new BorderLayout());
            panel3.add(textField3, BorderLayout.SOUTH);
        }
        contentPane.add(panel3, BorderLayout.SOUTH);

        //======== panel4 ========
        {
            panel4.setLayout(new BorderLayout());
        }
        contentPane.add(panel4, BorderLayout.EAST);
        pack();
        setLocationRelativeTo(getOwner());
        // JFormDesigner - End of component initialization  //GEN-END:initComponents
    }

    // JFormDesigner - Variables declaration - DO NOT MODIFY  //GEN-BEGIN:variables
    private JPanel center;
    private JLabel label1;
    private JPanel panel5;
    private JLabel label3;
    private JLabel label4;
    private JPanel panel6;
    private JTextField textField1;
    private JTextField textField2;
    private JButton button1;
    private JPanel panel7;
    private JPanel panel1;
    private JPanel panel2;
    private JPanel panel3;
    private JTextField textField3;
    private JPanel panel4;
    // JFormDesigner - End of variables declaration  //GEN-END:variables
}
