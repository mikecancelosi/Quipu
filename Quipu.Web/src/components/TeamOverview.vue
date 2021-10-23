<template>
  <q-layout>
    <q-drawer v-model="leftDrawerOpen" side="right" bordered :width="400">
      <div class="q-drawer-container">
        <h2 style="color: darkgray">What's the status?</h2>
        <div class="row">
          <q-btn no-caps outline dense>
            <q-avatar
              color="green-5"
              rounded
              size="10px"
              style="margin-right: 10px"
            />
            <div>On track</div>
          </q-btn>

          <q-btn no-caps outline>
            <q-avatar
              color="amber-5"
              rounded
              size="10px"
              style="margin-right: 10px"
            />
            <div>At risk</div>
          </q-btn>

          <q-btn no-caps outline>
            <q-avatar
              color="red-5"
              rounded
              size="10px"
              style="margin-right: 10px"
            />
            <div>Off track</div>
          </q-btn>
        </div>
      </div>

      <div>SHOW HISTORY</div>
    </q-drawer>

    <q-page-container>
      <div class="row">
        <q-space />
        <div id="overviewcontent" style="max-width: 800px; margin-top: 20px">
          <div id="collab-section">
            <h2>How we'll collaborate</h2>
            <q-input
              borderless
              placeholder="Welcome your team and set the tone for how you'll work together in Asana. Add meeting details, communication channels, and other important information."
              type="textarea"
            />
          </div>

          <div id="roles-section">
            <h2>Project roles</h2>
            <div class="row">
              <div class="row" style="align-items: center">
                <q-icon
                  name="o_add"
                  size="24px"
                  style="
                    border-style: dashed;
                    border-radius: 17px;
                    border-width: 1px;
                    margin-right: 10px;
                    padding: 5px;
                  "
                />
                <div>Add member</div>
              </div>
              <div class="row" v-for="member in this.team.Users" :key="member">
                <p>HELLO!</p>
              </div>
            </div>
          </div>

          <h2>Key Resources</h2>
          <div id="resource-container" class="row">
            <q-space />
            <q-icon
              name="mdi-clipboard-file-outline"
              size="100px"
              style="margin-right: 10px"
            />
            <div id="resource-empty" class="row">
              <p>
                Align your team around a shared vision with a project brief and
                supporting resources
              </p>
              <div class="row">
                <q-btn color="primary" label="Create project brief" />
                <q-btn outline label="Add links & files" />
              </div>
            </div>
            <q-space />
          </div>
        </div>
        <q-space />
      </div>
    </q-page-container>
  </q-layout>
</template>

<style scoped>
h2 {
  margin: 0px;
  font-size: 20px;
  font-weight: 400;
}

.q-drawer-container {
  padding: 10px;
}

.q-btn {
  margin-right: 10px;
  padding: 0px 10px;
}

#collab-section {
  margin-bottom: 50px;
}

#roles-section {
  margin-bottom: 50px;
}

#resource-container {
  width: 100%;
  min-height: 100px;
  justify-items: center;
  align-items: center;
  padding: 30px 0px;
  border-width: 1px;
  border-style: solid;
  border-radius: 10px;
}

#resource-empty {
  width: 50%;
}
</style>

<script>
export default {
  name: "TeamOverview",
  props: {
    team: {},
  },
  data() {
    return {
      leftDrawerOpen: true,
    };
  },
  methods: {},
  mounted() {},
};
</script>
