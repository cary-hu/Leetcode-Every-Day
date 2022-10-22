var originNumbers = [30, 32, 1075, 2];
var originOperators = ["*"];

const permute = (numbers, getPathLength) => {
  let path = [],
    result = [],
    used = {};

  numbers.forEach((element) => {
    if (used[element]) {
      used[element]++;
    } else {
      used[element] = 1;
    }
  });
  const backtracing = () => {
    if (path.length === getPathLength) {
      result.push(path.slice(0));
      return;
    }
    for (let i = 0; i < numbers.length; i += 1) {
      if (used[numbers[i]] == 0) continue;
      path.push(numbers[i]);
      used[numbers[i]]--;
      backtracing(i);
      used[numbers[i]]++;
      path.pop();
    }
  };
  backtracing();
  return result;
};
var permuteNumbers = permute(originNumbers, 4);
var permuteOperators = permute(originOperators, 3);

permuteNumbers.forEach((number) => {
  permuteOperators.forEach((operator) => {
    const expression = `(((${number[0]}${operator[0]}${number[1]})${operator[1]}${number[2]})${operator[2]}${number[3]})`;
    const res = eval(expression);
    if (res == 1024) {
      console.log(expression, eval(expression));
    }
  });
});
