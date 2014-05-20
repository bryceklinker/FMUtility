describe("App", function () {
    beforeEach(angular.mock.module("app"));

    it("should have PlayersController controller", function () {
        expected(app.PlayersController).toBeDefined();
    });
});