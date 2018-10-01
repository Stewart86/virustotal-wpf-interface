# virustotal-wpf-interface
A WPF interface for scanning of malicious files with VirusTotal web API

# The existance of this project

This project is created as a technical take-home test for a cyber sercurity company. This requirement was to solve a algorithm question with a function and also to create a executable to fetch API calls for scanning of files for virus.

The existance of this project is just to add on to my portfolio of projects I have completed. If you were handed on a similar questions, I hope you will find your own solution instead of cloning this repository to submit your work. I bear no responsibility for making full and direct copy of this repository. However, any comments and feedbacks are  welcomed as my test is already submitted. Any improvement will only be for my own learning purpose.

# Question One - Ladder challange

Give n number of steps on a ladder, compute a number of ways possible to climb the ladder with only a combination of 1 step or 2 steps at a time.
For example, input of 3 will derive to 3 possible ways ([1,1,1],[1,2],[2,1]). That is, 
- one step at a time to make it 3 steps
- one step and 2 steps to make it 3 steps
- or 2 steps first then one step to make it 3 steps

## Challange solved (answer)

To compute simple take `n` steps divided by 2 plus 1, and use a for-loop until the value is 1 loop below `n` steps.

    int result = 0;

    for (int i = steps / 2 + 1; i < steps; i++)
    {
        result += i;
    }

The rational behind this is for eample take `n` steps of 4, the number of possible ways would first adding 1 count of the most basic combination of `1,1,1,1` and last count of `2,2`. With that out of the way, the combination of numbers inbetween would be to include 2 steps in each combinations. as such, the possible combination would be `n / 2 + 1` for a `n` of 4, or any numbers.

    [2,1,1],
    [1,2,1],
    [1,1,2]

which would exhusted the combination of ones and twos with `n-1`. As the first loop of `int i` would end in one loop due to `i < steps` or `3 < 4`, `result = 0 + 3` and carried to the return statement below.

Taken these 3 possible combinations, together with the basic combinations mentioned above, even numbers will always have 2 additional combination and odd numbers will always have additional 1 number for their basic combiantions. Thus, returned result of even numbers must add 1 more than the odd numbers. 

    return steps % 2 == 0 ? result + 2 : result + 1;

Similar pattern emerged with any `n` numbers, for example with `n` of 6, first by excluding `[1,1,1,1,1,1]` and `[2,2,2]` which is 2 ways here. 

    2 ways of combinations
    [1,1,1,1,1,1]
    [2,2,2]

The number of combinations inbetween would be, and in reverse for clarity of the for-loop

    4 ways of combinations (n / 2 + 1)
    [2,1,1,2],
    [2,1,2,1],
    [2,2,1,1],
    [1,1,2,2],
    
    5 ways of combinations (n / 2 + 1) + 1
    [1,1,1,1,2],
    [1,1,1,2,1],
    [1,1,2,1,1],
    [1,2,1,1,1],
    [2,1,1,1,1],
    
Adding all up.
 
    subTotal = 5 + 4
    basic = 2
    Total = subTotal + basic
    
Total of 11 ways to climb the steps.

Any increase of `n` of steps will add additional for-loop to the computation. Which result to a big O notation of `O(n)`.
    
