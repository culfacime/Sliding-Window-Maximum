int[] MaxSlidingWindow1(int[] nums, int k)
{

    var steps = nums.Length - k + 1;

    var maxList = new int[steps];

    int maxInPart = nums[0];
    //ilk parçadaki max
    for (int j = 0; j < k; j++)
    {
        if (nums[j] > maxInPart)
        {
            maxInPart = nums[j];
        }
    }
    maxList[0] = maxInPart;

    for (int i = k - 1; i < steps; i++)
    {

        var inNumber = nums[i];
        var outNumber = nums[i - 1];

        //çıkan değer giren değerden büyükse yeniden hesapla
        if (inNumber > outNumber)
        {
            for (int j = i; j < i + k; j++)
            {
                if (nums[j] > maxInPart)
                {
                    maxInPart = nums[j];
                }
            }
        }

        maxList[i] = maxInPart;
    }

    return maxList;
}

int[] MaxSlidingWindow(int[] nums, int k)
{
    var steps = nums.Length - k + 1;

    var maxList = new int[steps];

    int max = nums[0];

    max = nums.Skip(0).Take(k).Max();
    //ilk parçadaki max
    //for (int j = 0; j < k; j++)
    //{
    //    if (nums[j] > max)
    //    {
    //        max = nums[j];
    //    }
    //}

    maxList[0] = max;


    for (int i = k; i < nums.Length; i++)
    {
        var inNumber = nums[i];
        var outNumber = nums[i-k];

        if (inNumber > max)
        {
            max = inNumber;
        }

        if (outNumber == max)
        {
            max = inNumber;
            for (int j = i-k+1; j <= i; j++)
            {
                if (nums[j] > max)
                    max = nums[j];
            }
        }

        maxList[i-k+1] = max;
    }

    return maxList;
}

int[] MaxSlidingWindowQueue(int[] nums, int k)
{
    var steps = nums.Length - k + 1;

    var maxList = new int[steps];

    var queue = new Queue<int>();
    for (int i = 0; i < k; i++)
    {
        queue.Enqueue(nums[i]);
    }
    maxList[0] = queue.Max();

    for (int i = k; i < nums.Length; i++)
    {
        queue.Dequeue();
        queue.Enqueue(nums[i]);

        maxList[i - k + 1] = queue.Max();
    }

    return maxList;
}


//passed 49/50 test
var mx = MaxSlidingWindow(new int[] { 1,-1 },1);

//passed 31/50 test
var mx3 = MaxSlidingWindow1(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);