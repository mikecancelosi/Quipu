import { mount } from "@cypress/vue";
import Cell from "../ProjectComponents/ProjectTaskList_PriorityCell.vue";
import createStore from "app/src/store/index";

var store;
let testPriority;
before(async () => {
  store = createStore();
  await store.dispatch("fetchPriorityTypes");
  testPriority = store.getters.getPriorityByID(1);
  console.log(testPriority);
});

describe("PriorityCell", () => {
  it("renders", () => {
    mount(Cell, {
      global: {
        plugins: [store],
      },
    });
    cy.get(".cell").should("be.visible");
  });

  it("displays initial value when applicable", () => {
    mount(Cell, {
      props: {
        priorityid: 1,
      },
      global: {
        plugins: [store],
      },
    });

    cy.get(".cell").should("contain", testPriority.name);
  });

  it("hides dropdown button by default", () => {
    mount(Cell, {
      global: {
        plugins: [store],
      },
    });

    cy.get("q-select__dropdown-icon").should("not.exist");
  });

  it("shows dropdown on hover", () => {
    mount(Cell, {
      global: {
        plugins: [store],
      },
    });

    cy.get(".cell").trigger("mouseenter");
    cy.get(".q-select__dropdown-icon").should("be.visible");
  });

  it("shows options", () => {
    mount(Cell, {
      props: {
        priorityid: 1,
      },
      global: {
        plugins: [store],
      },
    });

    cy.get(".cell").trigger("mouseenter");
    cy.get(".q-select__dropdown-icon").click();
    cy.contains("Priority 2");
  });

  it("displays new value on selection", () => {
    mount(Cell, {
      props: {
        priorityid: 1,
      },
      global: {
        plugins: [store],
      },
    });

    cy.get(".cell").trigger("mouseenter");
    cy.get(".q-select__dropdown-icon").click();
    cy.get(".q-badge").last().click();
    cy.contains("Priority ");
  });

  it("emits event on selection", () => {
    mount(Cell, {
      props: {
        priorityid: 1,
      },
      global: {
        plugins: [store],
      },
    });

    cy.get(".cell").trigger("mouseenter");
    cy.get(".q-select__dropdown-icon").click();
    cy.get(".q-badge")
      .last()
      .click()
      .should(() => {
        expect(Cypress.vueWrapper.emitted("update-task")).to.have.length(1);
      });
  });
});
