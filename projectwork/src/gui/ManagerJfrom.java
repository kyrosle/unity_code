/*
 * Created by JFormDesigner on Sun Aug 29 12:07:35 CST 2021
 */

package gui;

import java.awt.*;
import javax.swing.*;
import javax.swing.table.*;

/**
 * @author kyros
 */
public class ManagerJfrom extends JFrame {
    public ManagerJfrom() {
        initComponents();
    }

    private void initComponents() {
        // JFormDesigner - Component initialization - DO NOT MODIFY  //GEN-BEGIN:initComponents
        center = new JPanel();
        tabbedPane1 = new JTabbedPane();
        录入教师账号和密码 = new JPanel();
        button1 = new JButton();
        panel17 = new JPanel();
        panel16 = new JPanel();
        panel15 = new JPanel();
        密码 = new JPanel();
        label7 = new JLabel();
        textArea2 = new JTextArea();
        账户 = new JPanel();
        label6 = new JLabel();
        textArea1 = new JTextArea();
        panel18 = new JPanel();
        修改或删除教师 = new JPanel();
        panel19 = new JPanel();
        panel5 = new JPanel();
        panel20 = new JPanel();
        label8 = new JLabel();
        textField1 = new JTextField();
        button4 = new JButton();
        scrollPane1 = new JScrollPane();
        table1 = new JTable();
        button3 = new JButton();
        panel21 = new JPanel();
        textPane1 = new JTextPane();
        button2 = new JButton();
        查看个人信息 = new JPanel();
        panel6 = new JPanel();
        panel22 = new JPanel();
        label9 = new JLabel();
        textField2 = new JTextField();
        button5 = new JButton();
        scrollPane2 = new JScrollPane();
        table2 = new JTable();
        button6 = new JButton();
        查看所有教师账号信息 = new JPanel();
        scrollPane3 = new JScrollPane();
        table3 = new JTable();
        按姓名查找某个老师信息 = new JPanel();
        panel7 = new JPanel();
        panel23 = new JPanel();
        label10 = new JLabel();
        textField3 = new JTextField();
        button7 = new JButton();
        scrollPane4 = new JScrollPane();
        table4 = new JTable();
        editorPane1 = new JEditorPane();
        panel1 = new JPanel();
        panel2 = new JPanel();
        panel3 = new JPanel();
        panel4 = new JPanel();

        //======== this ========
        setMinimumSize(new Dimension(900, 600));
        setTitle("\u7ba1\u7406\u5458\u7cfb\u7edf");
        var contentPane = getContentPane();
        contentPane.setLayout(new BorderLayout());

        //======== center ========
        {
            center.setLayout(new BorderLayout());

            //======== tabbedPane1 ========
            {

                //======== 录入教师账号和密码 ========
                {
                    录入教师账号和密码.setLayout(new BorderLayout());

                    //---- button1 ----
                    button1.setText("\u786e\u8ba4\u5f55\u5165");
                    button1.setFont(button1.getFont().deriveFont(button1.getFont().getSize() + 5f));
                    录入教师账号和密码.add(button1, BorderLayout.PAGE_END);

                    //======== panel17 ========
                    {
                        panel17.setLayout(new FlowLayout());
                    }
                    录入教师账号和密码.add(panel17, BorderLayout.WEST);

                    //======== panel16 ========
                    {
                        panel16.setLayout(new FlowLayout());
                    }
                    录入教师账号和密码.add(panel16, BorderLayout.EAST);

                    //======== panel15 ========
                    {
                        panel15.setLayout(new BorderLayout());

                        //======== 密码 ========
                        {
                            密码.setLayout(new FlowLayout());

                            //---- label7 ----
                            label7.setText("\u6559\u5e08\u8d26\u6237 : ");
                            label7.setFont(label7.getFont().deriveFont(label7.getFont().getSize() + 10f));
                            密码.add(label7);

                            //---- textArea2 ----
                            textArea2.setColumns(15);
                            textArea2.setFont(textArea2.getFont().deriveFont(textArea2.getFont().getSize() + 10f));
                            密码.add(textArea2);
                        }
                        panel15.add(密码, BorderLayout.NORTH);

                        //======== 账户 ========
                        {
                            账户.setLayout(new FlowLayout());

                            //---- label6 ----
                            label6.setText("\u6559\u5e08\u5bc6\u7801 : ");
                            label6.setFont(label6.getFont().deriveFont(label6.getFont().getSize() + 10f));
                            账户.add(label6);

                            //---- textArea1 ----
                            textArea1.setColumns(15);
                            textArea1.setFont(textArea1.getFont().deriveFont(textArea1.getFont().getSize() + 10f));
                            账户.add(textArea1);
                        }
                        panel15.add(账户, BorderLayout.CENTER);
                    }
                    录入教师账号和密码.add(panel15, BorderLayout.CENTER);

                    //======== panel18 ========
                    {
                        panel18.setLayout(new FlowLayout(FlowLayout.CENTER, 5, 40));
                    }
                    录入教师账号和密码.add(panel18, BorderLayout.PAGE_START);
                }
                tabbedPane1.addTab("\u5f55\u5165\u6559\u5e08\u8d26\u53f7\u548c\u5bc6\u7801", 录入教师账号和密码);

                //======== 修改或删除教师 ========
                {
                    修改或删除教师.setLayout(new BorderLayout());

                    //======== panel19 ========
                    {
                        panel19.setLayout(new GridLayout(1, 2));

                        //======== panel5 ========
                        {
                            panel5.setLayout(new BorderLayout());

                            //======== panel20 ========
                            {
                                panel20.setLayout(new FlowLayout());

                                //---- label8 ----
                                label8.setText("\u4fee\u6539\u6559\u5e08 : ");
                                label8.setFont(label8.getFont().deriveFont(label8.getFont().getSize() + 10f));
                                panel20.add(label8);

                                //---- textField1 ----
                                textField1.setFont(textField1.getFont().deriveFont(textField1.getFont().getSize() + 5f));
                                textField1.setColumns(10);
                                panel20.add(textField1);

                                //---- button4 ----
                                button4.setText("\u67e5\u627e");
                                panel20.add(button4);
                            }
                            panel5.add(panel20, BorderLayout.PAGE_START);

                            //======== scrollPane1 ========
                            {

                                //---- table1 ----
                                table1.setModel(new DefaultTableModel(
                                    new Object[][] {
                                        {"", null, null, null, null},
                                        {null, null, null, null, null},
                                    },
                                    new String[] {
                                        "\u6559\u5e08\u8d26\u6237", "\u6559\u5e08\u5bc6\u7801", "ID", "\u59d3\u540d", "\u8054\u7cfb\u7535\u8bdd"
                                    }
                                ));
                                scrollPane1.setViewportView(table1);
                            }
                            panel5.add(scrollPane1, BorderLayout.CENTER);

                            //---- button3 ----
                            button3.setText("\u4fee\u6539\u5b8c\u6bd5");
                            button3.setFont(button3.getFont().deriveFont(button3.getFont().getSize() + 5f));
                            panel5.add(button3, BorderLayout.PAGE_END);
                        }
                        panel19.add(panel5);

                        //======== panel21 ========
                        {
                            panel21.setLayout(new FlowLayout());

                            //---- textPane1 ----
                            textPane1.setText("!!!\u5220\u9664\u7684\u4fe1\u606f\u65e0\u6cd5\u590d\u539f!!!");
                            textPane1.setFont(textPane1.getFont().deriveFont(textPane1.getFont().getSize() + 10f));
                            panel21.add(textPane1);

                            //---- button2 ----
                            button2.setText("\u786e\u8ba4\u5220\u9664");
                            button2.setFont(button2.getFont().deriveFont(button2.getFont().getSize() + 5f));
                            panel21.add(button2);
                        }
                        panel19.add(panel21);
                    }
                    修改或删除教师.add(panel19, BorderLayout.CENTER);
                }
                tabbedPane1.addTab("\u4fee\u6539\u6216\u5220\u9664\u6559\u5e08", 修改或删除教师);

                //======== 查看个人信息 ========
                {
                    查看个人信息.setLayout(new BorderLayout());

                    //======== panel6 ========
                    {
                        panel6.setLayout(new BorderLayout());

                        //======== panel22 ========
                        {
                            panel22.setLayout(new FlowLayout());

                            //---- label9 ----
                            label9.setText("\u67e5\u627e\u6559\u5e08 : ");
                            label9.setFont(label9.getFont().deriveFont(label9.getFont().getSize() + 10f));
                            panel22.add(label9);

                            //---- textField2 ----
                            textField2.setFont(textField2.getFont().deriveFont(textField2.getFont().getSize() + 5f));
                            textField2.setColumns(10);
                            panel22.add(textField2);

                            //---- button5 ----
                            button5.setText("\u67e5\u627e");
                            panel22.add(button5);
                        }
                        panel6.add(panel22, BorderLayout.PAGE_START);

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

                        //---- button6 ----
                        button6.setText("\u4fee\u6539\u5b8c\u6bd5");
                        button6.setFont(button6.getFont().deriveFont(button6.getFont().getSize() + 5f));
                        panel6.add(button6, BorderLayout.PAGE_END);
                    }
                    查看个人信息.add(panel6, BorderLayout.CENTER);
                }
                tabbedPane1.addTab("\u67e5\u770b\u4e2a\u4eba\u4fe1\u606f", 查看个人信息);

                //======== 查看所有教师账号信息 ========
                {
                    查看所有教师账号信息.setLayout(new BorderLayout());

                    //======== scrollPane3 ========
                    {

                        //---- table3 ----
                        table3.setModel(new DefaultTableModel(
                            new Object[][] {
                                {"", null, null, null, null},
                                {null, null, null, null, null},
                            },
                            new String[] {
                                "\u6559\u5e08\u8d26\u6237", "\u6559\u5e08\u5bc6\u7801", "ID", "\u59d3\u540d", "\u8054\u7cfb\u7535\u8bdd"
                            }
                        ));
                        scrollPane3.setViewportView(table3);
                    }
                    查看所有教师账号信息.add(scrollPane3, BorderLayout.CENTER);
                }
                tabbedPane1.addTab("\u67e5\u770b\u6240\u6709\u6559\u5e08\u8d26\u53f7\u4fe1\u606f", 查看所有教师账号信息);

                //======== 按姓名查找某个老师信息 ========
                {
                    按姓名查找某个老师信息.setLayout(new BorderLayout());

                    //======== panel7 ========
                    {
                        panel7.setLayout(new BorderLayout());

                        //======== panel23 ========
                        {
                            panel23.setLayout(new FlowLayout());

                            //---- label10 ----
                            label10.setText("\u6309\u59d3\u540d\u67e5\u627e\u6559\u5e08\u4fe1\u606f : ");
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

                        //======== scrollPane4 ========
                        {

                            //---- table4 ----
                            table4.setModel(new DefaultTableModel(
                                new Object[][] {
                                    {"", null, null, null, null},
                                    {null, null, null, null, null},
                                },
                                new String[] {
                                    "\u6559\u5e08\u8d26\u6237", "\u6559\u5e08\u5bc6\u7801", "ID", "\u59d3\u540d", "\u8054\u7cfb\u7535\u8bdd"
                                }
                            ));
                            scrollPane4.setViewportView(table4);
                        }
                        panel7.add(scrollPane4, BorderLayout.CENTER);
                    }
                    按姓名查找某个老师信息.add(panel7, BorderLayout.CENTER);
                }
                tabbedPane1.addTab("\u6309\u59d3\u540d\u67e5\u627e\u67d0\u4e2a\u8001\u5e08\u4fe1\u606f", 按姓名查找某个老师信息);

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
    private JPanel 录入教师账号和密码;
    private JButton button1;
    private JPanel panel17;
    private JPanel panel16;
    private JPanel panel15;
    private JPanel 密码;
    private JLabel label7;
    private JTextArea textArea2;
    private JPanel 账户;
    private JLabel label6;
    private JTextArea textArea1;
    private JPanel panel18;
    private JPanel 修改或删除教师;
    private JPanel panel19;
    private JPanel panel5;
    private JPanel panel20;
    private JLabel label8;
    private JTextField textField1;
    private JButton button4;
    private JScrollPane scrollPane1;
    private JTable table1;
    private JButton button3;
    private JPanel panel21;
    private JTextPane textPane1;
    private JButton button2;
    private JPanel 查看个人信息;
    private JPanel panel6;
    private JPanel panel22;
    private JLabel label9;
    private JTextField textField2;
    private JButton button5;
    private JScrollPane scrollPane2;
    private JTable table2;
    private JButton button6;
    private JPanel 查看所有教师账号信息;
    private JScrollPane scrollPane3;
    private JTable table3;
    private JPanel 按姓名查找某个老师信息;
    private JPanel panel7;
    private JPanel panel23;
    private JLabel label10;
    private JTextField textField3;
    private JButton button7;
    private JScrollPane scrollPane4;
    private JTable table4;
    private JEditorPane editorPane1;
    private JPanel panel1;
    private JPanel panel2;
    private JPanel panel3;
    private JPanel panel4;
    // JFormDesigner - End of variables declaration  //GEN-END:variables
}
