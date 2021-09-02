/*
 * Created by JFormDesigner on Sun Aug 29 12:10:13 CST 2021
 */

package gui;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import javax.swing.table.*;

/**
 * @author kyros
 */
public class StudentJfrom extends JFrame {
    public StudentJfrom() {
        initComponents();
    }

    private void tabbedPane1ComponentAdded(ContainerEvent e) {
        // TODO add your code here

    }

    private void initComponents() {
        // JFormDesigner - Component initialization - DO NOT MODIFY  //GEN-BEGIN:initComponents
        center = new JPanel();
        tabbedPane1 = new JTabbedPane();
        查看个人信息 = new JPanel();
        panel8 = new JPanel();
        scrollPane5 = new JScrollPane();
        table5 = new JTable();
        修改个人密码 = new JPanel();
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
        查看成绩 = new JPanel();
        scrollPane3 = new JScrollPane();
        table6 = new JTable();
        editorPane1 = new JEditorPane();
        panel1 = new JPanel();
        panel2 = new JPanel();
        panel3 = new JPanel();
        panel4 = new JPanel();

        //======== this ========
        setMinimumSize(new Dimension(900, 600));
        setTitle("\u5b66\u751f\u7cfb\u7edf");
        var contentPane = getContentPane();
        contentPane.setLayout(new BorderLayout());

        //======== center ========
        {
            center.setLayout(new BorderLayout());

            //======== tabbedPane1 ========
            {
                tabbedPane1.addContainerListener(new ContainerAdapter() {
                    @Override
                    public void componentAdded(ContainerEvent e) {
                        tabbedPane1ComponentAdded(e);
                    }
                });

                //======== 查看个人信息 ========
                {
                    查看个人信息.setLayout(new BorderLayout());

                    //======== panel8 ========
                    {
                        panel8.setLayout(new BorderLayout());

                        //======== scrollPane5 ========
                        {

                            //---- table5 ----
                            table5.setModel(new DefaultTableModel(
                                new Object[][] {
                                    {"", null, null, null, null, null, null},
                                    {null, null, null, null, null, null, null},
                                },
                                new String[] {
                                    "\u5b66\u751f\u8d26\u6237", "\u5b66\u751f\u5bc6\u7801", "ID", "\u59d3\u540d", "\u8054\u7cfb\u7535\u8bdd", "\u5bbf\u820d\u53f7", "\u73ed\u7ea7"
                                }
                            ));
                            table5.setCellSelectionEnabled(true);
                            table5.setBackground(new Color(102, 102, 102));
                            scrollPane5.setViewportView(table5);
                        }
                        panel8.add(scrollPane5, BorderLayout.CENTER);
                    }
                    查看个人信息.add(panel8, BorderLayout.CENTER);
                }
                tabbedPane1.addTab("\u67e5\u770b\u4e2a\u4eba\u4fe1\u606f", 查看个人信息);

                //======== 修改个人密码 ========
                {
                    修改个人密码.setLayout(new BorderLayout());

                    //======== panel15 ========
                    {
                        panel15.setLayout(new GridLayout(3, 3));

                        //======== 密码 ========
                        {
                            密码.setLayout(new FlowLayout());

                            //---- label7 ----
                            label7.setText("\u5b66\u751f\u539f\u5bc6\u7801 : ");
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
                            label9.setText("\u5b66\u751f\u65b0\u5bc6\u7801 : ");
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
                            label6.setText("\u786e\u8ba4\u5b66\u751f\u65b0\u5bc6\u7801 : ");
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
                }
                tabbedPane1.addTab("\u4fee\u6539\u4e2a\u4eba\u5bc6\u7801", 修改个人密码);

                //======== 查看成绩 ========
                {
                    查看成绩.setLayout(new BorderLayout());

                    //======== scrollPane3 ========
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
                        scrollPane3.setViewportView(table6);
                    }
                    查看成绩.add(scrollPane3, BorderLayout.CENTER);
                }
                tabbedPane1.addTab("\u67e5\u770b\u6210\u7ee9", 查看成绩);

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
    private JPanel panel8;
    private JScrollPane scrollPane5;
    private JTable table5;
    private JPanel 修改个人密码;
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
    private JPanel 查看成绩;
    private JScrollPane scrollPane3;
    private JTable table6;
    private JEditorPane editorPane1;
    private JPanel panel1;
    private JPanel panel2;
    private JPanel panel3;
    private JPanel panel4;
    // JFormDesigner - End of variables declaration  //GEN-END:variables
}
