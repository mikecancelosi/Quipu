import createStore from "app/src/store/index";

beforeAll(async () => {
  await setupStore();
});

var store;
async function setupStore() {
  store = createStore();
  await store.dispatch("fetchUsers");
}

const getStore = () => {
  return store;
};

module.exports = { getStore };
