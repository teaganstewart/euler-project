function fiboEvenSum(n) {

    // 0 1 2 3 5 8 13 21 34 55 89 ...
    let one = 1;
    let two = 2;

    let sum = 2;

    while (one + two <= n) {
        let three = one + two;
        if (three % 2 == 0) {
            sum += three;
        }

        one = two;
        two = three;
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
    let curr = goldenRatioCalculator(3);
    let i = 3;
    let sum = 0;

    while (curr <= n) {
        sum += curr;
        i += 3;
        curr = goldenRatioCalculator(i);
    }

    return sum;
}

let phi = 1.61803398875;
let phi1 = -0.61803398875;
let sqrt5 = 2.2360679775;

function power(a, b) {
    let res = 1;
    for(let i = 0; i < b; i++) {
        res *= a;
    }

    return res;
}

function goldenRatioCalculator(n) {
    return (power(phi, n) - power(phi1, n)) / sqrt5 | 0;
}

/**
 * Third approach: Using an Array.
 * 
 * The fastest approach so far.
 */
function arraySumFibonacci(n) {
    let arr = [2, 1, 2]; 
    for(let i = 3; i < n; i++) {
        arr[i] = arr[i-1] + arr[i-2];
        if(arr[i] > n) {
            break;
        }
        if(arr[i] % 2 === 0) {
            arr[0] += arr[i];
        }
    }


    return arr[0];
}

var start = new Date().getTime();

console.log("\nResult of golden ratio method for 10: " + fasterFibonacci(4000000));

var end = new Date().getTime();
var time = end - start;

console.log("Took " + time + " milliseconds\n");

var start = new Date().getTime();

console.log("Result of for loop method for 10: " + fiboEvenSum(4000000));

var end = new Date().getTime();
var time = end - start;

console.log("Took " + time + " milliseconds \n");

var start = new Date().getTime();

console.log("Result of array method for 10: " + arraySumFibonacci(4000000));

var end = new Date().getTime();
var time = end - start;

console.log("Took " + time + " milliseconds\n");


