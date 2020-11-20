function fiboEvenSum(n) {

    // 0 1 2 3 5 8 13 21 34 55 89 ...
    let one = 1;
    let two = 2;

    let sum = 2;
    let three = one + two;

    while (three <= n) {
        
        if (three % 2 == 0) {
            sum += three;
        }

        one = two;
        two = three;
        three = one + two;
    }

    return sum;
}

/**
 * Using facts about fibonacci sequence, I can use the fact that every 3rd fibonacci value will be divisible
 * by two, to my advantage. The Golden Ratio also helps to calculate any fibonacci number.
 * 
 * This was actually slower.
 */
function fasterFibonacci(n) {
    let curr = 2;
    let i = 3;
    let sum = 0;

    while (curr <= n) {
        sum += curr;
        i += 3;
        curr = (power(phi, i) - power(phi1, i)) / sqrt5 | 0;
    }

    return sum;
}

let phi = 1.61803398875;
let phi1 = -0.61803398875;
let sqrt5 = 2.2360679775;

function power(a, b) {
    let res = 1;
    for(let i = 0; i < b; ++i) {
        res *= a;
    }

    return res;
}

/**
 * Third approach: Using an Array.
 * 
 * The fastest approach so far.
 */
function arraySumFibonacci(n) {
    let arr = [0, 1, 2]; let i = 2;
    while(arr[i] < n) {
        
        if(arr[i] % 2 === 0) arr[0] += arr[i];
        i++;
        arr[i] = arr[i-1] + arr[i-2];
        
    }

    return arr[0];
}

function average(nums) {
    return nums.reduce((a, b) => (a + b)) / nums.length;
}

let times = [];
for(let i = 0; i < 1000000; ++i) {
    var start = new Date().getTime();

    fasterFibonacci(4000000);

    var end = new Date().getTime();
    var time = end - start;
    times.push(time);

}

console.log("\nGolden Ratio: Took " + average(times) + " milliseconds. Average of 1,000,000 runs.");


times = [];
for(let i = 0; i < 1000000; ++i) {
    var start = new Date().getTime();

    fiboEvenSum(4000000);

    var end = new Date().getTime();
    var time = end - start;
    times.push(time);
}

console.log("For Loop: Took " + average(times) + " milliseconds. Average of 1,000,000 runs. Result equals " + fiboEvenSum(4000000));

times = [];
for(let i = 0; i < 1000000; ++i) {
    var start = new Date().getTime();
    arraySumFibonacci(4000000);
    var end = new Date().getTime();
    var time = end - start;
    times.push(time);
}

console.log("Array: Took " + average(times) + " milliseconds. Average of 1,000,000 runs. Result equals " + arraySumFibonacci(4000000) + "\n");


