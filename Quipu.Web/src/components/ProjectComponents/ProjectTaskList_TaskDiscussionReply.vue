<template>
  <div class="reply row">
    <div class="col-1">
      <q-avatar color="red" text-color="white" size="35px">M</q-avatar>
    </div>
    <div class="col-11">
      <div class="column">
        <div class="col">
          <q-input
            outlined
            dense
            placeholder="Ask a question or post an update..."
          />
        </div>
        <div class="reply-footer row float-right">
          <a
            style="
              margin-right: 20px;
              font-size: 12px;
              color: rgb(255, 255, 255, 0.3);
            "
            >Collaborators</a
          >

          <div id="collab-section">
            <q-avatar
              class="contributorIcons"
              color="yellow"
              text-color="black"
              size="24px"
              >MC</q-avatar
            >
            <q-avatar
              class="contributorIcons"
              color="yellow"
              text-color="black"
              size="24px"
              >ED</q-avatar
            >
            <q-avatar
              class="contributorIcons"
              color="yellow"
              text-color="black"
              size="24px"
              >D</q-avatar
            >
          </div>
          <q-btn icon="o_add" disable flat rounded dense />

          <q-space />
          <q-btn icon="o_notifications" dense no-caps flat label="Leave task" />
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.reply {
  padding: 5px 20px;
}

.reply-footer {
  min-height: 40px;
  margin-top: 15px;
  align-items: center;
}

.contributorIcons {
  margin-right: 4px;
}
</style>

<script>
export default {
  name: "DiscussionReply",
};
</script>
