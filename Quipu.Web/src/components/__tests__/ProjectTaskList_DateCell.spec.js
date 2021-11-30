import { mount } from "@cypress/vue";
import Cell from "../ProjectComponents/ProjectTaskList_DateCell.vue";
import createStore from "app/src/store/index";
import { formatMMDD } from "../../utils/helpers/dateformatter";

var store;
before(async () => {
  store = createStore();
});

describe("DateCell", () => {
  it("renders", () => {
    mount(Cell, {
      global: {
        plugins: [store],
      },
    });
    cy.get(".cell").should("exist");
  });

  it("displays initial value when applicable", () => {
    const startDate = "2020-05-01T00:00:00";
    const endDate = "2020-05-02T00:00:00";
    const expectedValue = formatMMDD(startDate, endDate);
    mount(Cell, {
      props: {
        startDate: startDate,
        endDate: endDate,
      },
      global: {
        plugins: [store],
      },
    });
    cy.contains(expectedValue);
  });

  it("displays no initial value when applicable", () => {
    mount(Cell, {
      global: {
        plugins: [store],
      },
    });

    cy.get(".cell").should("be.empty");
  });

  it("shows calendar button on hover", () => {
    mount(Cell, {
      global: {
        plugins: [store],
      },
    });

    cy.get(".cell").trigger("mouseenter");
    cy.get(".q-btn").should("exist");
  });

  it("shows calendar on click", () => {
    mount(Cell, {
      global: {
        plugins: [store],
      },
    });

    cy.get(".cell").trigger("mouseenter");
    cy.get(".q-btn").click();
    cy.get(".q-date").should("exist");
  });

  it("emits event on selection", () => {
    mount(Cell, {
      global: {
        plugins: [store],
      },
    });

    cy.get(".cell").trigger("mouseenter");
    cy.get(".q-btn").click();
    cy.get(".q-date__calendar-item").eq(20).click();
    cy.get(".q-date__calendar-item")
      .eq(21)
      .click()
      .should(() => {
        expect(Cypress.vueWrapper.emitted("update-task")).to.have.length(1);
      });
  });
});
