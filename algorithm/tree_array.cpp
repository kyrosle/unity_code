#include <iostream>
using namespace std;
const int N=100;
int a[N]={0};// 元素数组
int t[N]={0};// b[i]数组
int c[N]={0};// ib[i]数组
int n=11;
int lowbe(int x){
    return x&(-x);
}

void init(){
    for(int i=1;i<n;i++){
        a[i]=i;
    }
}

// 单点修改,单点插入
// add(x,k)
// ask(x)-ask(x-1)
// 单点修改,区间查询
// ask(r)-ask(l-1)
// 区间修改,单点查询
// add(l,d);add(r+1,-d);
// a[x]+ask(x);
void add(int x,int k){
    for(;x<=n;x+=lowbe(x)){
        t[x]+=k;
    }
}
int ask(int x){
    int sum=0;
    for(;x>0;x-=lowbe(x)){
        sum+=t[x];
    }
    return sum;
}

// 区间修改,区间求和
void add1(int x,int k){
    for(;x<=n;x+=lowbe(x)){
       t[x]+=k;
    }
}
void add2(int x,int k){
    for(;x<=n;x+=lowbe(x)){
        c[x]+=k;
    }
}
int ask1(int x){
    int ans=0;
    for(;x;x-=lowbe(x)){
        ans+=t[x];
    }
    return ans;
}
int ask2(int x){
    int ans=0;
    for(;x;x-=lowbe(x)){
        ans+=c[x];
    }
    return ans;
}
// add1(l,d);add1(r+1,-d);add2(l,l*d);add2(r+1,-(r+1)*d);
// (sum[r]+(r+1)*ask(r)-ask2(r))-(sum[l-1]+l*ask1(l-1)-ask2(l-1))

int main()
{
   init(); 
}
