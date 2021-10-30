<template>
  <div class="reply row bg-dark">
    <div class="col-1">
      <q-avatar color="red" text-color="white" size="35px">M</q-avatar>
    </div>
    <div class="col-11">
      <div class="column">
        <div id="commentContainer" class="col" ref="commentContainer">
          <div id="inputContainer">
            <q-input
              class="inputbox"
              dense
              borderless
              autogrow
              v-model="inputval"
              placeholder="Ask a question or post an update..."
            />
          </div>
          <div id="inputFooterContainer">
            <div class="row float-left">
              <q-btn disable flat dense icon="o_text_format" />
              <q-btn disable flat dense icon="o_alternate_email" />
              <q-btn disable flat dense icon="o_emoji_emotions" />
              <q-btn disable flat dense icon="o_grade" />
              <q-btn disable flat dense icon="o_attach_file" />
            </div>
            <div class="row float-right">
              <q-btn
                id="commentBtn"
                color="primary"
                unelevated
                label="Comment"
                @click="submitComment()"
              />
            </div>
          </div>
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
  border-top: 1px solid rgba(255, 255, 255, 0.2);
  left: 0;
  right: 0;
}

.reply-footer {
  min-height: 40px;
  margin-top: 15px;
  align-items: center;
}

.contributorIcons {
  margin-right: 4px;
}

.expanded {
  min-height: 200px;
}

#commentContainer {
  border: 1px solid rgba(255, 255, 255, 0.2);
  border-radius: 5px;
  padding: 5px;
  display: flex;
  flex-direction: column;
  transition: min-height 200ms;
}

#commentContainer:focus-within {
  min-height: 150px;
  border: 1px solid rgba(255, 255, 255, 0.5);
}
#commentContainer:focus-within > #inputFooterContainer {
  height: fit-content;
  visibility: visible;
}

#inputContainer {
  flex-grow: 1;
}

#inputFooterContainer {
  height: 0px;
  visibility: hidden;
}
</style>

<script>
import { ref } from "vue";

export default {
  name: "DiscussionReply",
  emits: ["update-task"],
  setup(props, { emit }) {
    const inputval = ref("");

    const submitComment = () => {
      emit("update-task", inputval.value);
      inputval.value = "";
      document.activeElement.blur();
    };

    return { inputval, submitComment };
  },
};
</script>
