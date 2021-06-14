#include <iostream>
using namespace std;

typedef long long ll;

const int N=1e6;

ll w[N];

int n,m;

struct Node{
    int l,r;
    ll sum, d;
}tr[N*4];


ll gcd(ll a,ll b){
    return b?gcd(b,a%b):a;
}

void pushup(Node& u,Node& l,Node& r){
    u.sum=l.sum+r.sum;
    u.d=gcd(l.d,r.d);
}

void pushup(int u){
    pushup(tr[u],tr[u<<1],tr[u<<1|1]);
}

void build(int u,int l,int r){
    if(l==r){
        ll b=w[r]-w[l];
        tr[u]={l,r,b,b};
    }
    else {
        tr[u].l=l,tr[u].r=r;
        int mid=l+r>>1;
        build(u<<1,l,mid);
        build(u<<1|1,mid+1,r);
        pushup(u);
    }
}

void modify(int u,int x,ll v){
    if(tr[u].l==x&&tr[u].r==x){
        ll b=tr[u].sum+v;
        tr[u]={x,x,b,b};
    }
    else{
        int mid=tr[u].l+tr[u].r>>1;
        if(x<=mid)modify(u<<1,x,v);
        else modify(u<<1|1,x,v);
        pushup(u);
    }
}

Node query(int u,int l,int r){
    if(tr[u].l>=l&&tr[u].r<=r)return tr[u];
    else{
        int mid=tr[u].l+tr[u].r>>1;
        if(r<=mid)return query(u<<1,l,r);
        else if(l>mid)return query(u<<1|1,l,r);
        else{
            Node left=query(u<<1,l,r);
            Node right=query(u<<1,l,r);
            Node N;
            pushup(N,left,right);
            return N;
        }
    }
}

int main()
{
      cin >> n >> m;
    for(int i = 1; i <= n; i++) {scanf("%lld", &w[i]);}
    build(1, 1, n);
    
    int l, r;
    ll  v;
    char op[2];
    while(m -- ) {
        scanf("%s%d%d", op, &l, &r);
        if(*op == 'Q') {
            Node left = query(1, 1, l), right = query(1, l + 1, r);
            // cout << left.sum << " " << right.sum << endl;
            ll ans = abs(gcd(left.sum, right.d));
            cout << ans << endl;
        }
        else {
            scanf("%lld", &v);
            modify(1, l, v);
            if(r + 1 <= n) modify(1, r + 1, -v);
        }
    }
    return 0;
}

