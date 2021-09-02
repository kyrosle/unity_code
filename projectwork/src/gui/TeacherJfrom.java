/*
 * Created by JFormDesigner on Sun Aug 29 12:10:58 CST 2021
 */

package gui;

import java.awt.*;
import javax.swing.*;
import javax.swing.table.*;

/**
 * @author kyros
 */
public class TeacherJfrom extends JFrame {
    public TeacherJfrom() {
        initComponents();
    }

    private void initComponents() {
        // JFormDesigner - Component initialization - DO NOT MODIFY  //GEN-BEGIN:initComponents
        center = new JPanel();
        tabbedPane1 = new JTabbedPane();
        查看个人信息 = new JPanel();
        panel6 = new JPanel();
        scrollPane2 = new JScrollPane();
        table2 = new JTable();
        修改个人密码 = new JPanel();
        button1 = new JButton();
        panel17 = new JPanel();
        panel16 = new JPanel();
        panel15 = new JPanel();
        密码 = new JPanel();
        label7 = new JLabel();
        textArea2 = new JTextArea();
        密码2 = new JPanel();
        label9 = new JLabel();
        textArea3 = new JTextArea();
        账户 = new JPanel();
        label6 = new JLabel();
        textArea1 = new JTextArea();
        panel18 = new JPanel();
        录入学生账号和密码 = new JPanel();
        panel19 = new JPanel();
        button2 = new JButton();
        panel8 = new JPanel();
        panel32 = new JPanel();
        密码4 = new JPanel();
        label11 = new JLabel();
        textArea5 = new JTextArea();
        账户2 = new JPanel();
        label12 = new JLabel();
        textArea6 = new JTextArea();
        panel9 = new JPanel();
        录入学生成绩 = new JPanel();
        panel10 = new JPanel();
        panel31 = new JPanel();
        panel13 = new JPanel();
        label3 = new JLabel();
        textField4 = new JTextField();
        panel11 = new JPanel();
        label1 = new JLabel();
        textField1 = new JTextField();
        panel12 = new JPanel();
        label2 = new JLabel();
        textField2 = new JTextField();
        panel14 = new JPanel();
        label4 = new JLabel();
        textField5 = new JTextField();
        button3 = new JButton();
        查询或修改某个学生成绩 = new JPanel();
        panel7 = new JPanel();
        panel23 = new JPanel();
        label10 = new JLabel();
        textField3 = new JTextField();
        button7 = new JButton();
        panel20 = new JPanel();
        scrollPane3 = new JScrollPane();
        scrollPane6 = new JScrollPane();
        table6 = new JTable();
        panel21 = new JPanel();
        panel24 = new JPanel();
        label8 = new JLabel();
        textField7 = new JTextField();
        panel25 = new JPanel();
        label13 = new JLabel();
        textField8 = new JTextField();
        panel26 = new JPanel();
        label14 = new JLabel();
        textField9 = new JTextField();
        panel22 = new JPanel();
        button4 = new JButton();
        panel27 = new JPanel();
        panel28 = new JPanel();
        panel29 = new JPanel();
        panel30 = new JPanel();
        查看所有学生成绩 = new JPanel();
        scrollPane5 = new JScrollPane();
        table5 = new JTable();
        editorPane1 = new JEditorPane();
        panel1 = new JPanel();
        panel2 = new JPanel();
        panel3 = new JPanel();
        panel4 = new JPanel();

        //======== this ========
        setMinimumSize(new Dimension(900, 600));
        setTitle("\u6559\u5e08\u7cfb\u7edf");
        var contentPane = getContentPane();
        contentPane.setLayout(new BorderLayout());

        //======== center ========
        {
            center.setLayout(new BorderLayout());

            //======== tabbedPane1 ========
            {

                //======== 查看个人信息 ========
                {
                    查看个人信息.setLayout(new BorderLayout());

                    //======== panel6 ========
                    {
                        panel6.setLayout(new BorderLayout());

                        //======== scrollPane2 ========
                        {

                            //---- table2 ----
                            table2.setModel(new DefaultTableModel(
                                new Object[][] {
                                    {"", null, null, null, null},
                                    {null, null, null, null, null},
                                },
                                new String[] {
                                    "\u6559\u5e08\u8d26\u6237", "\u6559\u5e08\u5bc6\u7801", "ID", "\u59d3\u540d", "\u8054\u7cfb\u7535\u8bdd"
                                }
                            ));
                            scrollPane2.setViewportView(table2);
                        }
                        panel6.add(scrollPane2, BorderLayout.CENTER);
                    }
                    查看个人信息.add(panel6, BorderLayout.CENTER);
                }
                tabbedPane1.addTab("\u67e5\u770b\u4e2a\u4eba\u4fe1\u606f", 查看个人信息);

                //======== 修改个人密码 ========
                {
                    修改个人密码.setLayout(new BorderLayout());

                    //---- button1 ----
                    button1.setText("\u786e\u8ba4\u4fee\u6539");
                    button1.setFont(button1.getFont().deriveFont(button1.getFont().getSize() + 5f));
                    修改个人密码.add(button1, BorderLayout.PAGE_END);

                    //======== panel17 ========
                    {
                        panel17.setLayout(new FlowLayout());
                    }
                    修改个人密码.add(panel17, BorderLayout.WEST);

                    //======== panel16 ========
                    {
                        panel16.setLayout(new FlowLayout());
                    }
                    修改个人密码.add(panel16, BorderLayout.EAST);

                    //======== panel15 ========
                    {
                        panel15.setLayout(new GridLayout(3, 3));

                        //======== 密码 ========
                        {
                            密码.setLayout(new FlowLayout());

                            //---- label7 ----
                            label7.setText("\u6559\u5e08\u539f\u5bc6\u7801 : ");
                            label7.setFont(label7.getFont().deriveFont(label7.getFont().getSize() + 10f));
                            密码.add(label7);

                            //---- textArea2 ----
                            textArea2.setColumns(15);
                            textArea2.setFont(textArea2.getFont().deriveFont(textArea2.getFont().getSize() + 10f));
                            密码.add(textArea2);
                        }
                        panel15.add(密码);

                        //======== 密码2 ========
                        {
                            密码2.setLayout(new FlowLayout());

                            //---- label9 ----
                            label9.setText("\u6559\u5e08\u65b0\u5bc6\u7801 : ");
                            label9.setFont(label9.getFont().deriveFont(label9.getFont().getSize() + 10f));
                            密码2.add(label9);

                            //---- textArea3 ----
                            textArea3.setColumns(15);
                            textArea3.setFont(textArea3.getFont().deriveFont(textArea3.getFont().getSize() + 10f));
                            密码2.add(textArea3);
                        }
                        panel15.add(密码2);

                        //======== 账户 ========
                        {
                            账户.setLayout(new FlowLayout());

                            //---- label6 ----
                            label6.setText("\u786e\u8ba4\u6559\u5e08\u65b0\u5bc6\u7801 : ");
                            label6.setFont(label6.getFont().deriveFont(label6.getFont().getSize() + 10f));
                            账户.add(label6);

                            //---- textArea1 ----
                            textArea1.setColumns(15);
                            textArea1.setFont(textArea1.getFont().deriveFont(textArea1.getFont().getSize() + 10f));
                            账户.add(textArea1);
                        }
                        panel15.add(账户);
                    }
                    修改个人密码.add(panel15, BorderLayout.CENTER);

                    //======== panel18 ========
                    {
                        panel18.setLayout(new FlowLayout(FlowLayout.CENTER, 5, 40));
                    }
                    修改个人密码.add(panel18, BorderLayout.PAGE_START);
                }
                tabbedPane1.addTab("\u4fee\u6539\u4e2a\u4eba\u5bc6\u7801", 修改个人密码);

                //======== 录入学生账号和密码 ========
                {
                    录入学生账号和密码.setLayout(new BorderLayout(0, 20));

                    //======== panel19 ========
                    {
                        panel19.setLayout(new BorderLayout());

                        //---- button2 ----
                        button2.setText("\u786e\u8ba4\u5f55\u5165");
                        button2.setFont(button2.getFont().deriveFont(button2.getFont().getSize() + 5f));
                        panel19.add(button2, BorderLayout.PAGE_END);

                        //======== panel8 ========
                        {
                            panel8.setLayout(new GridLayout(3, 1));

                            //======== panel32 ========
                            {
                                panel32.setLayout(new BorderLayout());
                            }
                            panel8.add(panel32);

                            //======== 密码4 ========
                            {
                                密码4.setLayout(new FlowLayout());

                                //---- label11 ----
                                label11.setText("\u5b66\u751f\u8d26\u53f7 :       ");
                                label11.setFont(label11.getFont().deriveFont(label11.getFont().getSize() + 10f));
                                密码4.add(label11);

                                //---- textArea5 ----
                                textArea5.setColumns(15);
                                textArea5.setFont(textArea5.getFont().deriveFont(textArea5.getFont().getSize() + 10f));
                                密码4.add(textArea5);
                            }
                            panel8.add(密码4);

                            //======== 账户2 ========
                            {
                                账户2.setLayout(new FlowLayout());

                                //---- label12 ----
                                label12.setText("\u5b66\u751f\u8d26\u53f7\u5bc6\u7801 : ");
                                label12.setFont(label12.getFont().deriveFont(label12.getFont().getSize() + 10f));
                                账户2.add(label12);

                                //---- textArea6 ----
                                textArea6.setColumns(15);
                                textArea6.setFont(textArea6.getFont().deriveFont(textArea6.getFont().getSize() + 10f));
                                账户2.add(textArea6);
                            }
                            panel8.add(账户2);
                        }
                        panel19.add(panel8, BorderLayout.CENTER);

                        //======== panel9 ========
                        {
                            panel9.setLayout(new BorderLayout(30, 0));
                        }
                        panel19.add(panel9, BorderLayout.PAGE_START);
                    }
                    录入学生账号和密码.add(panel19, BorderLayout.CENTER);
                }
                tabbedPane1.addTab("\u5f55\u5165\u5b66\u751f\u8d26\u53f7\u548c\u5bc6\u7801", 录入学生账号和密码);

                //======== 录入学生成绩 ========
                {
                    录入学生成绩.setLayout(new BorderLayout());

                    //======== panel10 ========
                    {
                        panel10.setLayout(new GridLayout(5, 0));

                        //======== panel31 ========
                        {
                            panel31.setLayout(new BorderLayout());
                        }
                        panel10.add(panel31);

                        //======== panel13 ========
                        {
                            panel13.setLayout(new FlowLayout());

                            //---- label3 ----
                            label3.setText("\u5b66\u751fID :        ");
                            label3.setFont(label3.getFont().deriveFont(label3.getFont().getSize() + 5f));
                            panel13.add(label3);

                            //---- textField4 ----
                            textField4.setFont(textField4.getFont().deriveFont(textField4.getFont().getSize() + 5f));
                            textField4.setColumns(10);
                            panel13.add(textField4);
                        }
                        panel10.add(panel13);

                        //======== panel11 ========
                        {
                            panel11.setLayout(new FlowLayout());

                            //---- label1 ----
                            label1.setText("\u5b66\u751f\u6210\u7ee9 A : ");
                            label1.setFont(label1.getFont().deriveFont(label1.getFont().getSize() + 5f));
                            panel11.add(label1);

                            //---- textField1 ----
                            textField1.setFont(textField1.getFont().deriveFont(textField1.getFont().getSize() + 5f));
                            textField1.setColumns(10);
                            panel11.add(textField1);
                        }
                        panel10.add(panel11);

                        //======== panel12 ========
                        {
                            panel12.setLayout(new FlowLayout());

                            //---- label2 ----
                            label2.setText("\u5b66\u751f\u6210\u7ee9 B : ");
                            label2.setFont(label2.getFont().deriveFont(label2.getFont().getSize() + 5f));
                            panel12.add(label2);

                            //---- textField2 ----
                            textField2.setFont(textField2.getFont().deriveFont(textField2.getFont().getSize() + 5f));
                            textField2.setColumns(10);
                            panel12.add(textField2);
                        }
                        panel10.add(panel12);

                        //======== panel14 ========
                        {
                            panel14.setLayout(new FlowLayout());

                            //---- label4 ----
                            label4.setText("\u5b66\u751f\u6210\u7ee9 C : ");
                            label4.setFont(label4.getFont().deriveFont(label4.getFont().getSize() + 5f));
                            panel14.add(label4);

                            //---- textField5 ----
                            textField5.setFont(textField5.getFont().deriveFont(textField5.getFont().getSize() + 5f));
                            textField5.setColumns(10);
                            panel14.add(textField5);
                        }
                        panel10.add(panel14);
                    }
                    录入学生成绩.add(panel10, BorderLayout.CENTER);

                    //---- button3 ----
                    button3.setText("\u786e\u8ba4\u5f55\u5165");
                    button3.setFont(button3.getFont().deriveFont(button3.getFont().getSize() + 5f));
                    录入学生成绩.add(button3, BorderLayout.SOUTH);
                }
                tabbedPane1.addTab("\u5f55\u5165\u5b66\u751f\u6210\u7ee9", 录入学生成绩);

                //======== 查询或修改某个学生成绩 ========
                {
                    查询或修改某个学生成绩.setLayout(new BorderLayout());

                    //======== panel7 ========
                    {
                        panel7.setLayout(new BorderLayout());

                        //======== panel23 ========
                        {
                            panel23.setLayout(new FlowLayout());

                            //---- label10 ----
                            label10.setText("\u6309ID\u67e5\u627e\u5b66\u751f\u4fe1\u606f : ");
                            label10.setFont(label10.getFont().deriveFont(label10.getFont().getSize() + 10f));
                            panel23.add(label10);

                            //---- textField3 ----
                            textField3.setFont(textField3.getFont().deriveFont(textField3.getFont().getSize() + 5f));
                            textField3.setColumns(10);
                            panel23.add(textField3);

                            //---- button7 ----
                            button7.setText("\u67e5\u627e");
                            panel23.add(button7);
                        }
                        panel7.add(panel23, BorderLayout.PAGE_START);

                        //======== panel20 ========
                        {
                            panel20.setLayout(new BorderLayout());

                            //======== scrollPane3 ========
                            {

                                //======== scrollPane6 ========
                                {

                                    //---- table6 ----
                                    table6.setModel(new DefaultTableModel(
                                        new Object[][] {
                                            {"", null, null, null, null},
                                            {null, null, null, null, null},
                                        },
                                        new String[] {
                                            "\u5b66\u751f\u59d3\u540d", "\u5b66\u751fID", "\u79d1\u76eeA", "\u79d1\u76eeB", "\u79d1\u76eeC"
                                        }
                                    ));
                                    scrollPane6.setViewportView(table6);
                                }
                                scrollPane3.setViewportView(scrollPane6);
                            }
                            panel20.add(scrollPane3, BorderLayout.WEST);

                            //======== panel21 ========
                            {
                                panel21.setLayout(new GridLayout(4, 0));

                                //======== panel24 ========
                                {
                                    panel24.setLayout(new FlowLayout());

                                    //---- label8 ----
                                    label8.setText("\u5b66\u751f\u6210\u7ee9 A : ");
                                    label8.setFont(label8.getFont().deriveFont(label8.getFont().getSize() + 5f));
                                    panel24.add(label8);

                                    //---- textField7 ----
                                    textField7.setFont(textField7.getFont().deriveFont(textField7.getFont().getSize() + 5f));
                                    textField7.setColumns(10);
                                    panel24.add(textField7);
                                }
                                panel21.add(panel24);

                                //======== panel25 ========
                                {
                                    panel25.setLayout(new FlowLayout());

                                    //---- label13 ----
                                    label13.setText("\u5b66\u751f\u6210\u7ee9 B : ");
                                    label13.setFont(label13.getFont().deriveFont(label13.getFont().getSize() + 5f));
                                    panel25.add(label13);

                                    //---- textField8 ----
                                    textField8.setFont(textField8.getFont().deriveFont(textField8.getFont().getSize() + 5f));
                                    textField8.setColumns(10);
                                    panel25.add(textField8);
                                }
                                panel21.add(panel25);

                                //======== panel26 ========
                                {
                                    panel26.setLayout(new FlowLayout());

                                    //---- label14 ----
                                    label14.setText("\u5b66\u751f\u6210\u7ee9 C : ");
                                    label14.setFont(label14.getFont().deriveFont(label14.getFont().getSize() + 5f));
                                    panel26.add(label14);

                                    //---- textField9 ----
                                    textField9.setFont(textField9.getFont().deriveFont(textField9.getFont().getSize() + 5f));
                                    textField9.setColumns(10);
                                    panel26.add(textField9);
                                }
                                panel21.add(panel26);

                                //======== panel22 ========
                                {
                                    panel22.setLayout(new BorderLayout(40, 10));

                                    //---- button4 ----
                                    button4.setText("\u786e\u8ba4\u4fee\u6539");
                                    button4.setFont(button4.getFont().deriveFont(button4.getFont().getSize() + 5f));
                                    panel22.add(button4, BorderLayout.CENTER);

                                    //======== panel27 ========
                                    {
                                        panel27.setLayout(new BorderLayout());
                                    }
                                    panel22.add(panel27, BorderLayout.WEST);

                                    //======== panel28 ========
                                    {
                                        panel28.setLayout(new BorderLayout());
                                    }
                                    panel22.add(panel28, BorderLayout.NORTH);

                                    //======== panel29 ========
                                    {
                                        panel29.setLayout(new BorderLayout());
                                    }
                                    panel22.add(panel29, BorderLayout.EAST);

                                    //======== panel30 ========
                                    {
                                        panel30.setLayout(new BorderLayout());
                                    }
                                    panel22.add(panel30, BorderLayout.SOUTH);
                                }
                                panel21.add(panel22);
                            }
                            panel20.add(panel21, BorderLayout.CENTER);
                        }
                        panel7.add(panel20, BorderLayout.CENTER);
                    }
                    查询或修改某个学生成绩.add(panel7, BorderLayout.CENTER);
                }
                tabbedPane1.addTab("\u67e5\u8be2\u6216\u4fee\u6539\u67d0\u4e2a\u5b66\u751f\u6210\u7ee9", 查询或修改某个学生成绩);

                //======== 查看所有学生成绩 ========
                {
                    查看所有学生成绩.setLayout(new BorderLayout());

                    //======== scrollPane5 ========
                    {

                        //---- table5 ----
                        table5.setModel(new DefaultTableModel(
                            new Object[][] {
                                {"", null, null, null, null},
                                {null, null, null, null, null},
                            },
                            new String[] {
                                "\u5b66\u751f\u59d3\u540d", "\u5b66\u751fID", "\u79d1\u76eeA", "\u79d1\u76eeB", "\u79d1\u76eeC"
                            }
                        ));
                        scrollPane5.setViewportView(table5);
                    }
                    查看所有学生成绩.add(scrollPane5, BorderLayout.CENTER);
                }
                tabbedPane1.addTab("\u67e5\u770b\u6240\u6709\u5b66\u751f\u6210\u7ee9", 查看所有学生成绩);

                tabbedPane1.setSelectedIndex(0);
            }
            center.add(tabbedPane1, BorderLayout.CENTER);

            //---- editorPane1 ----
            editorPane1.setText("\u7cfb\u7edf\u4fe1\u606f");
            editorPane1.setAlignmentX(1.0F);
            editorPane1.setCursor(Cursor.getPredefinedCursor(Cursor.TEXT_CURSOR));
            editorPane1.setCaretPosition(4);
            center.add(editorPane1, BorderLayout.NORTH);
        }
        contentPane.add(center, BorderLayout.CENTER);

        //======== panel1 ========
        {
            panel1.setLayout(new BorderLayout(80, 40));
        }
        contentPane.add(panel1, BorderLayout.WEST);

        //======== panel2 ========
        {
            panel2.setLayout(new BorderLayout(40, 40));
        }
        contentPane.add(panel2, BorderLayout.SOUTH);

        //======== panel3 ========
        {
            panel3.setLayout(new BorderLayout(40, 40));
        }
        contentPane.add(panel3, BorderLayout.EAST);

        //======== panel4 ========
        {
            panel4.setLayout(new BorderLayout(40, 40));
        }
        contentPane.add(panel4, BorderLayout.NORTH);
        pack();
        setLocationRelativeTo(getOwner());
        // JFormDesigner - End of component initialization  //GEN-END:initComponents
    }

    // JFormDesigner - Variables declaration - DO NOT MODIFY  //GEN-BEGIN:variables
    private JPanel center;
    private JTabbedPane tabbedPane1;
    private JPanel 查看个人信息;
    private JPanel panel6;
    private JScrollPane scrollPane2;
    private JTable table2;
    private JPanel 修改个人密码;
    private JButton button1;
    private JPanel panel17;
    private JPanel panel16;
    private JPanel panel15;
    private JPanel 密码;
    private JLabel label7;
    private JTextArea textArea2;
    private JPanel 密码2;
    private JLabel label9;
    private JTextArea textArea3;
    private JPanel 账户;
    private JLabel label6;
    private JTextArea textArea1;
    private JPanel panel18;
    private JPanel 录入学生账号和密码;
    private JPanel panel19;
    private JButton button2;
    private JPanel panel8;
    private JPanel panel32;
    private JPanel 密码4;
    private JLabel label11;
    private JTextArea textArea5;
    private JPanel 账户2;
    private JLabel label12;
    private JTextArea textArea6;
    private JPanel panel9;
    private JPanel 录入学生成绩;
    private JPanel panel10;
    private JPanel panel31;
    private JPanel panel13;
    private JLabel label3;
    private JTextField textField4;
    private JPanel panel11;
    private JLabel label1;
    private JTextField textField1;
    private JPanel panel12;
    private JLabel label2;
    private JTextField textField2;
    private JPanel panel14;
    private JLabel label4;
    private JTextField textField5;
    private JButton button3;
    private JPanel 查询或修改某个学生成绩;
    private JPanel panel7;
    private JPanel panel23;
    private JLabel label10;
    private JTextField textField3;
    private JButton button7;
    private JPanel panel20;
    private JScrollPane scrollPane3;
    private JScrollPane scrollPane6;
    private JTable table6;
    private JPanel panel21;
    private JPanel panel24;
    private JLabel label8;
    private JTextField textField7;
    private JPanel panel25;
    private JLabel label13;
    private JTextField textField8;
    private JPanel panel26;
    private JLabel label14;
    private JTextField textField9;
    private JPanel panel22;
    private JButton button4;
    private JPanel panel27;
    private JPanel panel28;
    private JPanel panel29;
    private JPanel panel30;
    private JPanel 查看所有学生成绩;
    private JScrollPane scrollPane5;
    private JTable table5;
    private JEditorPane editorPane1;
    private JPanel panel1;
    private JPanel panel2;
    private JPanel panel3;
    private JPanel panel4;
    // JFormDesigner - End of variables declaration  //GEN-END:variables
}
