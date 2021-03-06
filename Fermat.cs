using System;
 
class Fermat
{
	public static long LongRandom(long min, long max, Random rand) {
		byte[] buf = new byte[8];
		rand.NextBytes(buf);
		long longRand = BitConverter.ToInt64(buf, 0);
		return (Math.Abs(longRand % (max - min)) + min);
	}
    public static long gcd(long a, long b, long x, long y)
    {
        if (a == 0){
            x = 0;
            y = 1;
            return b;
        }
        long x1 = 1, y1 = 1; 
        long aux = gcd(b % a, a, x1, y1);
        x = y1 - (b / a) * x1;
        y = x1;
        return aux;
    }
	private static long exponentiation(long num_base, long num_exponent, long mod) 
    {
        long answer = 1;
        for (int x = 0; x < num_exponent; x++)
        {answer = (answer * num_base) % mod;}
        return answer;
    }
	private static void noprim(long a){
		Console.WriteLine("The number " + a + " is NOT a prime number");
		System.Environment.Exit(1);
	}
	private static void prim(long a){
		Console.WriteLine("The number " + a + " IS a prime number");
		System.Environment.Exit(1);
	}
	public static bool check(long a, int k){
		long b = LongRandom(1,a,new Random());
		long d = gcd(b,a,1,1); // creates a number between 1 and a
		if(d > 1) return false;
		if(d == 1) d = exponentiation(b,a-1,a);
		if(d != 1) return false;
		else {
			if(k > 0)check(a,k-1);
			else return true;
		}
		return true;
	}
     
    static public void Main (string[] args)
    {
        long num = Int64.Parse(args[0]);
		if(num%2 == 0) noprim(num);  
		if(check(num,10)) prim(num);
		else noprim(num);
    }
}