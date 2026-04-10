import java.util.*;

class Solution {
    public boolean isSubsequence(String s, String t) {
        int val = 0;
        for(int i = 0 ; i<s.length(); i++){
            for(int j = 0 ; j<t.length(); j++){
            if(s.charAt(i)==t.charAt(j)){
                val++;
                break;
            }
            }
        }

        if(val==s.length()){
            return true;
        }
        else{
            return false;
        }
    }
 }


/* solution 
class Solution {
    public boolean isSubsequence(String s, String t) {
        int x=s.length();
        int y=t.length();
        if(x==0)
            return true;
        int i=0,j=0;
        while(i<x && j<y)
        {
            if (s.charAt(i)==t.charAt(j))
            {
                i++;
                j++;
                if(i==x)
                    return true;
            }
            else
                j++;
        }
        return false;
        
    }
}



