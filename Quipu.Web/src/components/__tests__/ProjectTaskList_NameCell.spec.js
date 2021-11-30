import { mount } from "@cypress/vue";
import Cell from "../ProjectComponents/ProjectTaskList_NameCell.vue";
import createStore from "app/src/store/index";

var store;
let testtask;
before(async () => {
  store = createStore();
  await store.dispatch("fetchTasks");
  await store.dispatch("fetchUsers");
  testtask = store.getters.getTaskByID(1);
});

describe("NameCell", () => {
  it("renders", () => {
    mount(Cell, {
      global: {
        plugins: [store],
      },
      props: {
        task: testtask,
      },
    });
    cy.dataCy("input").should("be.visible");
  });

  it("displays initial value when applicable", () => {
    mount(Cell, {
      props: {
        task: testtask,
      },
      global: {
        plugins: [store],
      },
    });
    cy.get("input")
      .invoke("val")
      .then((textval) => expect(textval).to.equal(testtask.name));
  });

  it("name value is editable", () => {
    mount(Cell, {
      props: {
        task: testtask,
      },
      global: {
        plugins: [store],
      },
    });
    const textToCheck = "NewTaskName";

    cy.dataCy("input").type(textToCheck);
    cy.get("input")
      .invoke("val")
      .then((textval) => expect(textval).to.contain(textToCheck));
  });

  it("name value change emits event", () => {
    mount(Cell, {
      props: {
        task: testtask,
      },
      global: {
        plugins: [store],
      },
    });
    const textToCheck = "NewTaskName";
    cy.dataCy("input").type(textToCheck);
    cy.dataCy("input")
      .blur()
      .should(() => {
        expect(Cypress.vueWrapper.emitted("update-task")).to.have.length(1);
      });
  });

  it("set task name to empty emits event", () => {
    mount(Cell, {
      props: {
        task: testtask,
      },
      global: {
        plugins: [store],
      },
    });
    cy.dataCy("input").clear();
    cy.dataCy("input")
      .blur()
      .should(() => {
        expect(Cypress.vueWrapper.emitted("remove-task")).to.have.length(1);
      });
  });

  it("details button is hidden without hover", () => {
    mount(Cell, {
      props: {
        task: testtask,
      },
      global: {
        plugins: [store],
      },
    });

    cy.get("#detailsbtn").should("not.be.visible");
  });

  it("details button is shown on hover", () => {
    mount(Cell, {
      props: {
        task: testtask,
      },
      global: {
        plugins: [store],
      },
    });
    cy.task("activateHoverPseudo", { selector: ".cell" });
    cy.get("#detailsbtn").should("be.visible");
  });

  it("details button emits event on click", () => {
    mount(Cell, {
      props: {
        task: testtask,
      },
      global: {
        plugins: [store],
      },
    });
    cy.task("activateHoverPseudo", { selector: ".cell" });
    cy.get("#detailsbtn")
      .click()
      .should(() => {
        expect(Cypress.vueWrapper.emitted("detail-task")).to.have.length(1);
      });
  });
});
