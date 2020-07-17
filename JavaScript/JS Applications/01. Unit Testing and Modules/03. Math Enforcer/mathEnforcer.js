//Judge contest - https://judge.softuni.bg/Contests/Practice/Index/335#3

const expect = require('chai').expect;

let mathEnforcer = {
    addFive: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2) {
        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};

describe('mathEnforcer', function() {
    const validIntParam = 10;
    const validFloatParam = 5.5;
    const validNegativeParam = -10;
    const invalidInput = '5';
    const allowedDelta = 0.01;

    let correctResult;

    describe('addFive', function() {
        it('should return undefined with non-number input', function(){
            expect(mathEnforcer.addFive(invalidInput)).to.equal(undefined);
        });

        it('should return correct result with floating point number', function(){
            correctResult = 10.5
            expect(mathEnforcer.addFive(validFloatParam)).to.be.closeTo(correctResult, allowedDelta);
        });

        it('should return correct result with negative number', function(){
            correctResult = -5;
            expect(mathEnforcer.addFive(validNegativeParam)).to.equal(correctResult);
        });
    });

    describe('subtractTen', function() {

        it('should return undefined with non-number input', function(){
            expect(mathEnforcer.subtractTen(invalidInput)).to.equal(undefined);
        });

        it('should return correct result with floating point number', function(){
            correctResult = -4.5;
            expect(mathEnforcer.subtractTen(validFloatParam)).to.be.closeTo(correctResult, allowedDelta);
        });

        it('should return correct result with negative number', function(){
            correctResult = -20;
            expect(mathEnforcer.subtractTen(-validIntParam)).to.equal(correctResult);
        });
    });

    describe('sum', function() {
        it('should return undefined with non-number first parameter', function(){
            expect(mathEnforcer.sum(invalidInput, validIntParam)).to.equal(undefined);
        });

        it('should return undefined with non-number second parameter', function(){
            expect(mathEnforcer.sum(validIntParam, invalidInput)).to.equal(undefined);
        });

        it('should return correct result with floating point numbers', function(){
            correctResult = 11.0;
            expect(mathEnforcer.sum(validFloatParam,validFloatParam)).to.be.closeTo(correctResult, allowedDelta);
        });

        it('should return correct result with negative numbers', function(){
            correctResult = -15.5;
            expect(mathEnforcer.sum(-validIntParam, -validFloatParam)).to.equal(correctResult);
        });
    });
})