//Judge contest - https://judge.softuni.bg/Contests/Practice/Index/335#2

const expect = require('chai').expect;

function lookupChar(string, index) {
    if (typeof(string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }

    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}

describe('lookupChar', function() {
    const validString = '123';
    const validIndex = 1;
    const correctResult = '2';

    const inputStringLength = validString.length;
    const negativeInputIndex = -1;
    const floatingPointIndex = 2.5;

    it('should return undefined with non-string first parameter', function(){
        expect(lookupChar(validIndex, validIndex)).to.equal(undefined);
    });
    
    it('should return undefined with non-integer second parameter', function(){
        expect(lookupChar(validString, validString)).to.equal(undefined);
    });    

    it('should return undefined with floating point second parameter', function(){
        expect(lookupChar(validString, floatingPointIndex)).to.equal(undefined);
    });

    it('should return incorrect index with negative second parameter', function(){
        expect(lookupChar(validString, negativeInputIndex)).to.equal('Incorrect index');
    });
    
    //Not required in Judge
    it('should return incorrect index with second parameter bigger than the first parameter length', function(){
        expect(lookupChar(validString, inputStringLength + 1)).to.equal('Incorrect index');
    });

    it('should return incorrect index with second parameter equal to the first parameter length', function(){
        expect(lookupChar(validString, inputStringLength)).to.equal('Incorrect index');
    });

    it('should return correct result with valid parameters', function(){
        expect(lookupChar(validString, validIndex)).to.equal(correctResult);
    });
})