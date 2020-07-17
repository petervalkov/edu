//Judge contest - https://judge.softuni.bg/Contests/Practice/Index/756#1

const expect = require('chai').expect;
const StringBuilder = require('./StringBuilder.js');

describe('StringBuilder', function() {
    const validConstructorParam = 'constructor parameter';
    const validFunctionParam = 'function parameter';
    const validIndexParam = 2
    const nonStringParam = {};

    let validInstance = null;

    describe('constructor', function() {
        it('should throw error with non-string parameter', function(){
            expect(() => new StringBuilder(nonStringParam)).to.throw();
        });

        it('should create instance with empty string', function(){
            expect(() => new StringBuilder('')).to.not.throw();
        });

        it('should create valid instance without parameter', function () {
            validInstance = new StringBuilder();
            expect(validInstance.hasOwnProperty('_stringArray')).to.equal(true, 'missing _stringArray');
            expect(Object.getPrototypeOf(validInstance).hasOwnProperty('append')).to.equal(true, 'missing append');
            expect(Object.getPrototypeOf(validInstance).hasOwnProperty('prepend')).to.equal(true, 'missing prepend');
            expect(Object.getPrototypeOf(validInstance).hasOwnProperty('insertAt')).to.equal(true, 'missing insertAt');
            expect(Object.getPrototypeOf(validInstance).hasOwnProperty('remove')).to.equal(true, 'missing remove');
            expect(Object.getPrototypeOf(validInstance).hasOwnProperty('toString')).to.equal(true, 'missing toString');
        });

        it('should initialize the given data to array', function () {
            validInstance = new StringBuilder(validConstructorParam);

            expect(validInstance._stringArray instanceof Array).to.equal(true);
            expect(validInstance._stringArray).to.eql(Array.from(validConstructorParam));
        });
    });

    describe('append', function() {
        beforeEach(function () {
            validInstance = new StringBuilder(validConstructorParam);
        });

        it('should throw error with non-string parameter', function(){
            expect(() => validInstance.append(nonStringParam)).to.throw();
        });

        it('should add the value at the end', function(){
            const expectedResult = Array.from(validConstructorParam + validFunctionParam);
            validInstance.append(validFunctionParam);
            expect(validInstance._stringArray).to.eql(expectedResult);
        });
    });

    describe('prepend', function() {
        beforeEach(function () {
            validInstance = new StringBuilder(validConstructorParam);
        });

        it('should throw error with non-string parameter', function(){
            expect(() => validInstance.prepend(nonStringParam)).to.throw();
        });

        it('should add the value at the beginning', function(){
            const expectedResult = Array.from(validFunctionParam + validConstructorParam);
            validInstance.prepend(validFunctionParam);
            
            expect(validInstance._stringArray).to.eql(expectedResult);
        });
    });

    describe('insertAt', function() {
        beforeEach(function () {
            validInstance = new StringBuilder(validConstructorParam);
        });

        it('should throw error with invalid first parameter', function(){
            expect(() => validInstance.insertAt(invalidStringParam, validIndexParam)).to.throw();
        });

        it('should add the value at the given index', function(){
            const expectedResult = Array.from(validConstructorParam);
            expectedResult.splice(validIndexParam, 0, ...validFunctionParam);
            validInstance.insertAt(validFunctionParam, validIndexParam);
            
            expect(validInstance._stringArray).to.eql(expectedResult);
        });
    });

    describe('remove', function() {
        beforeEach(function () {
            validInstance = new StringBuilder(validConstructorParam);
        });

        it('should remove the given count strating from the given index', function(){
            const removeCount = 3;
            const expectedResult = Array.from('coructor parameter');
            validInstance.remove(validIndexParam, removeCount);
            
            expect(validInstance._stringArray).to.eql(expectedResult);
        });
    });

    describe('toString', function() {
        it('should return correct value', function(){
            validInstance = new StringBuilder(validConstructorParam);
            expect(validInstance.toString()).to.equal(validConstructorParam);
        });
    });
});