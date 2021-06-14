#include <iostream>

using namespace std;
const int N = 200010;

struct tree{
    int l, r, val;
}f[N * 4];
int m, p;


//求子节点的最大值并且赋值给父节点
void pushup(int u) {
    f[u].val = max(f[u << 1].val, f[u << 1 | 1].val);
}

//从下标l开始建树到r
void build(int u, int l, int r) {
    //每一次给父节点的表示范围标记
    f[u] = {l, r};
    //如果左右节点相同，代表已近走到最末尾，建树结束
    if(l == r) return;
    //取中间值
    int mid = l + r >> 1;
    //右建树
    build(u << 1, l, mid);
    //左建数
    build(u << 1 | 1, mid + 1, r);
}

//查询操作
int query(int u, int l ,int r) {
    //如果该节点包含在查询区间里面，直接返回节点值
    if(f[u].l >= l && f[u].r <= r) return f[u].val;
    
    //取改节点中间值
    int mid = f[u].l + f[u].r >> 1;
    int v = 0;
    //如果l<=mid,代表该节点的左边有一部分包含在查询区间里面,进行查询
    if(l <= mid) v = query(u << 1, l, r);        
    //如果r > mid,代表右边有一部分在查询区间里，进行查询
    if(r >  mid) v = max(v, query(u << 1 | 1, l, r));
    //返回值
    return v;
}

//更新节点操作
void modifly(int u, int x, int v) {
    //如果左右节点同时等于需要更新的X，进行更新操作
    if(f[u].l == x && x ==  f[u].r) f[u].val = v;
    else {
        //如果不是
        //取改节点中间值
        int mid = f[u].l + f[u].r >> 1;
        //如果需要更新的值在左边，去左子数进行更新操作
        if(x <= mid) modifly(u << 1, x, v);
        //否则去右子树进行更新操作
        else modifly(u << 1 | 1, x, v);
        //对父节点进行更新操作
        pushup(u);
    }
}

int main() {
    int n = 0, last = 0;
    cin >> m >> p;
    int k = m;
    build(1, 1, m);
    char op[2]; int x;
    while(m--) {
        scanf("%s%d", op, &x);
        if(*op == 'Q') {
            last = query(1, n - x + 1, n);
            cout << last << endl;
        }
        else {
            modifly(1, n + 1, (last + x) % p);
            n++;
        }
    }
    return 0;
}
