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

To compute simple take `n` steps divided by 2 plus 1, and use a for loop to until the value is 1 number below `n` steps.

    int result = 0;

    for (int i = steps / 2 + 1; i < steps; i++)
    {
        result += i;
    }

As even numbers will always have 1 additional combination than odd numbers. returned result must add 1 more than the odd numbers. 

    return steps % 2 == 0 ? result + 2 : result + 1;
