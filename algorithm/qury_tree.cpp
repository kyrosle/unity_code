#include<iostream>
using namespace std;
const int N=1e3;

void build_tree(int a[],int tree[],int node,int start,int end){
    if(start==end){
        tree[node]=a[start];
        return;
    }
    int mid= (start+end)/2;
    int left_node  = 2 * node +1;
    int right_node = 2 * node +2;
    build_tree(a, tree, left_node, start, mid);
    build_tree(a, tree, right_node, mid+1, end);
    tree[node]=tree[left_node]+tree[right_node];
}

void update_tree(int a[],int tree[],int node,int start,int end,int idx,int val){
    if(start==end){
        tree[node]=val;
        a[idx]=val;
        return;
    }
    int mid=(start+end)/2;
    int left_node  = 2 * node +1;
    int right_node = 2 * node +2;
    if(idx<=mid&&idx>=start){
        update_tree(a, tree, left_node, start, mid, idx, val);
    }else{
        update_tree(a, tree, right_node, mid+1, end, idx, val);
    }
    tree[node]= tree[left_node]+tree[right_node];
}

int qury_tree(int a[],int tree[],int node,int start,int end,int L,int R){
    printf("start = %d\n",start);
    printf("end   = %d\n",end);
    cout<<endl;
    if(start==end){
        return tree[node];
    }
    if(L<=start&&end<=R){
        return tree[node];
    }
    if(L>end||R<start){
        return 0;
    }
    int mid=(start+end)/2;
    int left_node  = 2 * node +1;
    int right_node = 2 * node +2;
    int lsum=qury_tree(a, tree, left_node, start, mid, L, R);
    int rsum=qury_tree(a, tree, right_node, mid+1, end, L, R);
    return lsum+rsum;
    
}



int main()
{
    int a[]={1,3,5,7,9,11};
    int size=6;
    int tree[N]={0};

    build_tree(a, tree, 0, 0, size-1);

    for(int i=0;i<size*2+3;i++){
        printf("tree[%d] = %d\n",i,tree[i]);
    }

    cout<<endl;

    update_tree(a, tree, 0, 0, size-1, 4, 6);

    for(int i=0;i<size*2+3;i++){
        printf("tree[%d] = %d\n",i,tree[i]);
    }
    
    cout<<endl<<qury_tree(a, tree, 0, 0, size-1, 2, 5)<<endl;
        
}
