#include<iostream>
using namespace std;
const int N=1e5;
struct Node{
    int l,r; // 左右端点
    int tmax;// 当前区间的最大的字段和
    int lmax;// 最大前缀和
    int rmax;// 最大后缀和
    int sum; // 本区间和
}tree[N*4];
int a[N];
void pushup(Node& u,Node& l,Node& r){
    // 最大连续字段和: 在左子 ; 在右子 ; 横跨左右
    u.tmax=max(l.tmax,max(r.tmax,r.lmax+l.rmax));
    // 前缀和: 左边的最大前缀和 ; 左边和总和+右边的最大前缀和
    u.lmax=max(l.lmax,l.sum+r.lmax);
    // 后缀和: 右边的最大后缀和 ; 右边的总和+左边的最大后缀和
    u.rmax=max(r.rmax,r.sum+l.rmax);
    u.sum=l.sum+r.sum;
}

void pushup(int u){
    pushup(tree[u], tree[u<<1], tree[u<<1|1]);
}

void build(int u,int l,int r){
    if(l==r)tree[u]={l,r,a[r],a[r],a[r],a[r]};
    else {
        tree[u]={l,r};
        int mid=l+r>>1;
        build(u<<1,l,mid);
        build(u<<1|1,mid+1,r);
        pushup(u);
    }
}
// u 当前位置   x 要改的位置    v修改成的值
void modify(int u,int x,int v){
    if(tree[u].l==x&&tree[u].r==x)tree[u]={x,x,v,v,v,v};
    else{
        int mid=tree[u].l+tree[u].r>>1;
        if(x<=mid)modify(u<<1, x, v);
        else modify(u<<1|1, x, v);
        pushup(u);
    }
}
Node query(int u,int l,int r){
    if(tree[u].l>=l&&tree[u].r<=r){
        return tree[u];
    }else{
        int mid=tree[u].l+tree[u].r>>1;
        if(r<=mid)return query(u<<1, l, r);
        else if(mid<l)return query(u<<1|1, l, r);
        else{
            auto tr1=query(u<<1, l, r);
            auto tr2=query(u<<1|1,l,r);
            Node node;
            pushup(node,tr1,tr2);
            return node;
        }
    }

}

int main()
{
    int n,m;
    cin>>n>>m;
    for(int i=1;i<=n;i++){
        cin>>a[i];
    }
    build(1, 1, n);
    while (m--) {
        int c,x,y;
        cin>>c>>x>>y;
        if(c==1){
            if(x>y)swap(x,y);
            Node u=query(1,x,y);
            cout<<u.tmax<<endl;
        }else{
            modify(1,x, y);
        }
    }
}
