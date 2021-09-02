package Information.ITools;

public class Performace {
    int A = 0;
    int B = 0;
    int C = 0;
    public Performace(){}

    public Performace(int a,int b,int c){
        setA(a);
        setB(b);
        setC(c);
    }
    public int getA() {
        return A;
    }

    public void setA(int a) {
        A = a;
    }

    public int getB() {
        return B;
    }

    public void setB(int b) {
        B = b;
    }

    public int getC() {
        return C;
    }

    public void setC(int c) {
        C = c;
    }
    @Override
    public String toString(){
        return getA() + " " +
                getB() + " " +
                getC() + "\n";
    }
}
