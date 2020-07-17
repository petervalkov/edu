//Judge contest - https://judge.softuni.bg/Contests/Practice/Index/974#1

const expect = require('chai').expect;
const PaymentPackage = require('./PaymentPackage.js');

describe('PaymentPackage', function() {
    const correctStringParam = 'name';
    const correctNumberParam = 1000;
    const correctNewNumberParam = 0;
    const defaultVAT = 20;

    let validInstance = null;

    describe('constructor', function() {
        it('should throw error without parameters', function(){
            expect(() => new PaymentPackage()).to.throw();
        });
    
        it('should throw error with one parameter', function(){
            expect(() => new PaymentPackage(correctStringParam)).to.throw();
        });

        it('should set correct default parameters', function(){
            validInstance = new PaymentPackage(correctStringParam, correctNumberParam);

            expect(validInstance.VAT).to.equal(defaultVAT, 'wrong VAT');
            expect(validInstance.active).to.equal(true, 'wrong active');
        });

        it('should create instance with all properties', function(){
            validInstance = new PaymentPackage(correctStringParam, correctNumberParam);

            expect(validInstance.hasOwnProperty('_name')).to.equal(true, 'missing name');
            expect(validInstance.hasOwnProperty('_value')).to.equal(true, 'missing value');
            expect(validInstance.hasOwnProperty('_VAT')).to.equal(true, 'missing VAT');
            expect(validInstance.hasOwnProperty('_active')).to.equal(true, 'missing active');
        });
    });

    describe('name', function() {
        beforeEach(function () {
            validInstance = new PaymentPackage(correctStringParam, correctNumberParam);
        });

        it('setter should throw error with non-string parameter', function(){
            expect(() => validInstance.name = correctNumberParam).to.throw();
        });

        it('setter should throw error with empty string parameter', function(){
            expect(() => validInstance.name = '').to.throw();
        });

        it('getter and setter should get/set correct value', function(){
            validInstance.name = 'new name';
            expect(validInstance.name).to.equal('new name');
        });
    });

    describe('value', function() {
        beforeEach(function () {
            validInstance = new PaymentPackage(correctStringParam, correctNumberParam);
        });

        it('setter should throw error with non-number parameter', function(){
            expect(() => validInstance.value = correctStringParam).to.throw();
        });

        it('setter should throw error with negative number parameter', function(){
            expect(() => validInstance.value = -1).to.throw();
        });

        it('getter and setter should get/set correct value', function(){
            validInstance.value = correctNewNumberParam;
            expect(validInstance.value).to.equal(correctNewNumberParam);
        });
    });

    describe('VAT', function() {
        beforeEach(function () {
            validInstance = new PaymentPackage(correctStringParam, correctNumberParam);
        });

        it('setter should throw error with non-number parameter', function(){
            expect(() => validInstance.VAT = correctStringParam).to.throw();
        });

        it('setter should throw error with negative number parameter', function(){
            expect(() => validInstance.VAT = -1).to.throw();
        });

        it('getter and setter should get/set correct value', function(){
            validInstance.VAT = correctNewNumberParam;
            expect(validInstance.VAT).to.equal(correctNewNumberParam);
        });
    });

    describe('active', function() {
        beforeEach(function () {
            validInstance = new PaymentPackage(correctStringParam, correctNumberParam);
        });

        it('setter should throw error with non-boolean parameter', function(){
            expect(() => validInstance.active = correctStringParam).to.throw();
        });

        it('getter and setter should get/set correct value', function(){
            validInstance.active = false;
            expect(validInstance.active).to.equal(false);
        });
    });

    describe('toString', function() {
        beforeEach(function () {
            validInstance = new PaymentPackage(correctStringParam, correctNumberParam);
        });

        it('should return correct result when active', function(){
            const expected = 'Package: name\n- Value (excl. VAT): 1000\n- Value (VAT 20%): 1200';
            const actualResult = validInstance.toString();

            expect(actualResult).to.equal(expected);
        });

        it('should return correct result when inactive', function(){
            validInstance.active = false;
            const expected = 'Package: name (inactive)\n- Value (excl. VAT): 1000\n- Value (VAT 20%): 1200';
            const actualResult = validInstance.toString();

            expect(actualResult).to.equal(expected);
        });
    });
});