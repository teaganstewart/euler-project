function multiplesOf3and5(number) {

    let sum = 0;
  
    for(let i = 3; i < number; i+=3 ) {
      sum+=i;
    }
    for(let i = 5; i < number; i+=5) {
      if(i%3 != 0) {
        sum+=i;
      }
    }
  
    return sum;
}

// Required Tests:
console.log();
console.log(multiplesOf3and5(1000) + ". Should equal 233168.");
console.log(multiplesOf3and5(10) + ". Should equal 23.");
console.log(multiplesOf3and5(49) + ". Should equal 543.");
console.log(multiplesOf3and5(8456) + ". Should equal 16687353.");
console.log(multiplesOf3and5(19564) + ". Should equal 89301183.");
console.log();