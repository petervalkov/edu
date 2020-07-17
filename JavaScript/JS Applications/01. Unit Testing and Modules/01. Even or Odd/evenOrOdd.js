//Judge contest - https://judge.softuni.bg/Contests/Practice/Index/335#1

const expect = require('chai').expect;

function isOddOrEven(string) {
    if (typeof(string) !== 'string') {
        return undefined;
    }

    if (string.length % 2 === 0) {
        return "even";
    }

    return "odd";
}

describe('isOddOrEven', function() {
    it('should return undefined with non-string parameter', function(){
        expect(isOddOrEven({})).to.equal(undefined);
    });
    
    it('should return correct result with odd parameter length', function(){
        expect(isOddOrEven('xxx')).to.equal('odd');
    });

    it('should return correct result with even parameter length', function(){
        expect(isOddOrEven('xxxx')).to.equal('even');
    });

    //Not required in Judge
    it('should return correct result with with multiple consecutive checks', function(){
        expect(isOddOrEven('xxx')).to.equal('odd');
        expect(isOddOrEven('xxxx')).to.equal('even');
    });
})