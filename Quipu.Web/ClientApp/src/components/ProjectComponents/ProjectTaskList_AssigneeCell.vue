<template>
    <div class="cell"
         @mouseenter="hover = true"
         @mouseleave="hover = false">
        <q-btn icon="o_person_outline"
               round
               outline
               dense
               size="10px"
               v-if="hover &&
                     !showdropdown &&
                     newuser == null"
               @click="assignUserClicked()"
               :style="{ visibility: newuser == null
                                             ? 'visible'
                                             : 'collapse'}" />

        <q-select dense
                  ref="userselect"
                  v-model="newuser"
                  :hide-dropdown-icon="!hover && !showdropdown"
                  :options="allUserDropdownOptions"
                  @update:model-value="updatetask()"
                  @popup-hide="showdropdown = false"
                  v-if="showdropdown ||  newuser != null"
                  borderless
                  emit-value>
            <template v-slot:option="scope">
                <q-item v-bind="scope.itemProps">
                    <q-item-section>
                        {{scope.opt.label}}
                    </q-item-section>
                </q-item>
            </template>

            <template v-slot:selected>
                {{newuser != null ? newuser.display_Name : ''}}
            </template>
        </q-select>


    </div>
</template>

<style scoped>
    .cell{
        width:100%;
        height:100%;
    }

</style>

<script>
    import { mapGetters, mapActions } from 'vuex'

    export default {
        name: "AssigneeCell",
        emits: ["update-task"],
        computed: mapGetters(['allUsers', 'allUserDropdownOptions']),
        created() {
            this.fetchUsers();
        },
        props: {
            user: {},           
        },
        data() {
            return {
                hover: false,
                showdropdown: false,
                newuser: this.user,
            }
        },
        methods: {
            assignUserClicked() {
                this.showdropdown = true;
                this.$nextTick(() => { this.$refs.userselect.showPopup() });
            },
            updatetask() {
                this.$emit("update-task",this.newuser);
            },
            ...mapActions(['fetchUsers']),
        },
        updated() {
            this.newuser = this.user;
        }

    }
</script>