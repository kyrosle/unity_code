package main;


import com.alibaba.fastjson.JSON;

import java.util.LinkedList;
import java.util.List;


public class test1 {

    public static void main(String[] args) {

        test one = new test("a",1);
        test two = new test("aa",11);
        String a,b;
        a = JSON.toJSONString(one);
        b = JSON.toJSONString(two);
        System.out.println(a);
        System.out.println(b);

        String ja,jb;
        ja = "{\"a\":\"a\",\"b\":1}";
        jb = "{\"a\":\"aa\",\"b\":11}";

        test tone,ttwo;
        tone = JSON.parseObject(ja,test.class);
        ttwo = JSON.parseObject(jb,test.class);
        System.out.println(tone.a);
        System.out.println(ttwo.a);

        List<test> list = new LinkedList<>();
        list.add(one);
        list.add(two);

        String str = JSON.toJSONString(list);
        System.out.println(str);

        String lstr = "[{\"a\":\"a\",\"b\":1},{\"a\":\"aa\",\"b\":11}]";
        List<test>glist = new LinkedList<>();
        glist = JSON.parseArray(lstr,test.class);
        for (var s :
                glist) {
            System.out.println(s.a);

        }
    }
}

class test{
    public String a;
    public int b;
    public test(){}
    public test(String _a,int _b){
        a=_a;
        b=_b;
    }

}